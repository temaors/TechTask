using BotDetect.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TechTask.Configurations;
using TechTask.DataBase;
using TechTask.MappingProfiles;
using TechTask.Models.Entities;
using TechTask.Repositories;
using TechTask.Services.Messaging;
using TechTask.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped(typeof(IRepository<User>), typeof(Repository<User>));
builder.Services.AddScoped(typeof(IRepository<BusinessArea>), typeof(Repository<BusinessArea>));
builder.Services.AddScoped(typeof(IRepository<Location>), typeof(Repository<Location>));

builder.Services.AddScoped(typeof(ICaptchaValidator), typeof(ReCaptchaValidator));
var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddAutoMapper(typeof(ContactInfoMappingProfile), typeof(LocationMappingProfile), typeof(UserMappingProfile));

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.Name = ".TechTask.Session";
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Register}/{action=ContactInfoForm}/{id?}");

app.Run();