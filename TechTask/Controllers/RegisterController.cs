using AutoMapper;
using BotDetect.Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TechTask.Models;
using TechTask.Models.Entities;
using CountryData.Standard;
using TechTask.Models.Enums;
using TechTask.Models.ViewModels;
using TechTask.Repositories;
using TechTask.Services.Messaging;
using TechTask.Validators;

namespace TechTask.Controllers;


public class RegisterController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILogger<RegisterController> _logger;
    private IRepository<User> _userRepository;
    private IRepository<BusinessArea> _businessAreaRepository;
    //private readonly EmailSender _emailSender;

    
    public RegisterController(ILogger<RegisterController> logger, IRepository<User> userRepository, IMapper mapper, IRepository<BusinessArea> businessAreaRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
        _mapper = mapper;
        _businessAreaRepository = businessAreaRepository;
        //_emailSender = emailSender;
    }
    public IActionResult ContactInfoForm()
    {
        ViewData["StepInfo"] = "STEP 1: Contact Info";
        return View("ContactInfoForm");
    }
    
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmContactInfo(ContactInfoViewModel model, string button)
    {
        if (TryValidateModel(model) && model.Email == model.EmailConfirmation)
        {
            HttpContext.Session.SetObjectAsJson("contactInfo", model);
            ModelState.Clear();
            ViewData["StepInfo"] = "STEP 2: Areas";
            return View("AreasForm", GetBusinessAreaViewModel());
        }

        if (model.Email != model.EmailConfirmation)
        {
            model.EmailConfirmation = "";
        }
        ViewData["StepInfo"] = "STEP 1: Contact Info";
        return View("ContactInfoForm", model);
    }
    
    public BusinessAreaViewModel GetBusinessAreaViewModel()
    {
        var businessAreas = Enum.GetValues(typeof(BusinessAreas))
            .Cast<BusinessAreas>()
            .Select((value, index) => new BusinessAreaViewModel.Area
            {
                Id = index,
                Name = value.ToString(),
                IsSelected = false
            }).ToList();
        BusinessAreaViewModel businessAreaViewModel = new BusinessAreaViewModel()
        {
            Areas = businessAreas,
        };
        return businessAreaViewModel;
    }
    
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmAreas(string? button, BusinessAreaViewModel model)
    {
        if (button == "next")
        {
            if(ModelState.IsValid && IsBusinessAreasValid(model))
            {
                HttpContext.Session.SetObjectAsJson("area", model);
                ViewData["StepInfo"] = "STEP 3: Address";
                return View("AddressForm");
            }
            ViewData["StepInfo"] = "STEP 2: Areas";
            return View("AreasForm", model);
        }
        ViewData["StepInfo"] = "STEP 1: Contact Info";
        return View("ContactInfoForm", HttpContext.Session.GetObjectFromJson<ContactInfoViewModel>("contactInfo"));
    }

    public bool IsBusinessAreasValid(BusinessAreaViewModel model)
    {
        foreach (var businessAreas in model.Areas)
        {
            if (businessAreas.IsSelected)
            {
                return true;
            }
        }
        return false;
    }
    
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmAddress(AddressViewModel model, string? button)
    {
        if (button == "next")
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObjectAsJson("address", model);
                ViewData["StepInfo"] = "STEP 4: Password";
                return View("PasswordForm");
            }
            ViewData["StepInfo"] = "STEP 3: Address";
            return View("AddressForm", model);
        }
        ViewData["StepInfo"] = "STEP 2: Address";
        return View("AreasForm", HttpContext.Session.GetObjectFromJson<BusinessAreaViewModel>("area"));
    }
    
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmPassword(PasswordViewModel model, string? button)
    {
        if (button == "next")
        {
            if (ModelState.IsValid && PasswordValidator.IsValid(model.Pass) && model.Pass==model.ConfirmPass && model.IsTermsAccepted)
            {
                HttpContext.Session.SetObjectAsJson("password", model);
                await SaveUserData();
                ViewData["StepInfo"] = "STEP 5: Completed";
                return View("Completed");
            }

            if (model.Pass != model.ConfirmPass)
            {
                model.ConfirmPass = "";
            }
            ViewData["StepInfo"] = "STEP 4: Password";
            return View("PasswordForm", model);
        }
        ViewData["StepInfo"] = "STEP 3: Address";
        return View("AddressForm", HttpContext.Session.GetObjectFromJson<AddressViewModel>("address"));
    }

    
    private async Task SaveUserData()
    {
        var contactInfoModel = HttpContext.Session.GetObjectFromJson<ContactInfoViewModel>("contactInfo");
        var areasModel = HttpContext.Session.GetObjectFromJson<BusinessAreaViewModel>("area");
        areasModel.Areas.RemoveAll(x => !x.IsSelected);
        var addressModel = HttpContext.Session.GetObjectFromJson<AddressViewModel>("address");
        var passwordModel = HttpContext.Session.GetObjectFromJson<PasswordViewModel>("password");
        
        User user = _mapper.Map<User>(passwordModel);
        user.BusinessAreas = _mapper.Map<List<BusinessAreaViewModel.Area>, List<BusinessArea>>(areasModel.Areas);
        user.ContactInfo = _mapper.Map<ContactInfo>(contactInfoModel);
        user.Location = _mapper.Map<Location>(addressModel);

        await _userRepository.Create(user);
    }
}