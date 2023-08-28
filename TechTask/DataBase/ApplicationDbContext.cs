using Microsoft.EntityFrameworkCore;
using TechTask.Models.Entities;

namespace TechTask.DataBase;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<User>? Users { get; set; }
    public DbSet<ContactInfo>? ContactInfos { get; set; }
    public DbSet<Location>? Locations { get; set; }
    public DbSet<BusinessArea>? BusinessAreas { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BusinessArea>().HasData(
            new BusinessArea[] 
            {
                new BusinessArea { Id=1, Name="Finance"},
                new BusinessArea { Id=2, Name="It"},
                new BusinessArea { Id=3, Name="Operations"},
                new BusinessArea { Id=4, Name="Sales"},
                new BusinessArea { Id=5, Name="Administrative"},
                new BusinessArea { Id=6, Name="Legal"},
                new BusinessArea { Id=7, Name="Marketing"}
            });
    }
}