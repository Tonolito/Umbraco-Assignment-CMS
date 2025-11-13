using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco_Assignment_CMS.Models;
using Umbraco_Assignment_CMS.Services;
using Umbraco_Assignment_CMS.ViewModels;

namespace Umbraco_Assignment_CMS.Controllers;

public class FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, FormSubmissonsService formSubmissonsService, EmailService emailService) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
{
    private readonly FormSubmissonsService _formSubmissonsService = formSubmissonsService;
    private readonly EmailService _emailService = emailService;
    public async Task<IActionResult> HandleCallbackForm(CallbackFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }
        var result = _formSubmissonsService.SaveCallbackRequest(model);

        if (!result)
        {
            // FormError
            TempData["FormError"] = "Something went wrong while submitting you request. Please try again later.";
            return RedirectToCurrentUmbracoPage();
        }

        var emailConfirmModel = new EmailConfirmRequest
        {
            Email = model.Email
        };


        var emailServiceResult = await _emailService.SendEmailConfirmation(emailConfirmModel);

        if (!emailServiceResult)
        {
            Console.WriteLine("EMAIL SERVICE FAILED");
            return RedirectToCurrentUmbracoPage();

        }

        // FormSuccess
        TempData["FormSuccess"] = "Thank you! Your Request have been noted. Thank you!";
        return RedirectToCurrentUmbracoPage();
    }
    public async Task<IActionResult> HandleQuestionForm(QuestionFormViewmodel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }
        var result = _formSubmissonsService.SaveQuestionRequest(model);

        if (!result)
        {
            // FormError
            TempData["FormError"] = "Something went wrong while submitting you request. Please try again later.";
            return RedirectToCurrentUmbracoPage();
        }

        var emailConfirmModel = new EmailConfirmRequest
        {
            Email = model.Email
        };


        var emailServiceResult = await _emailService.SendEmailConfirmation(emailConfirmModel);

        if (!emailServiceResult)
        {
            Console.WriteLine("EMAIL SERVICE FAILED");
            return RedirectToCurrentUmbracoPage();

        }

        // FormSuccess
        TempData["FormSuccess"] = "Thank you! Your Request have been noted. Thank you!";
        return RedirectToCurrentUmbracoPage();
    }

    public async Task<IActionResult> HandleEmailForm(EmailFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }
        var result = _formSubmissonsService.SaveEmailRequest(model);

        if (!result)
        {
            // FormError
            TempData["EmailFormError"] = "Something went wrong while submitting you request. Please try again later.";
            return RedirectToCurrentUmbracoPage();
        }

        var emailConfirmModel = new EmailConfirmRequest
        {
            Email = model.ContactEmail
        };


        var emailServiceResult = await _emailService.SendEmailConfirmation(emailConfirmModel);

        if(!emailServiceResult)
        {
            Console.WriteLine("EMAIL SERVICE FAILED");
            return RedirectToCurrentUmbracoPage();

        }
        // FormSuccess
        TempData["EmailFormSuccess"] = "Your Request have been noted. Thank you!";
        return RedirectToCurrentUmbracoPage();
    }
}
