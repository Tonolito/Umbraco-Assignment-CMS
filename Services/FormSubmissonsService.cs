using Umbraco.Cms.Core.Services;
using Umbraco_Assignment_CMS.ViewModels;

namespace Umbraco_Assignment_CMS.Services;

public class FormSubmissonsService(IContentService contentService)
{
    private readonly IContentService _contentService = contentService;

    public bool SaveCallbackRequest(CallbackFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "formSubmissons");
            if (container == null)
            {
                return false;
            }

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} -  {model.Name}";
            var request = _contentService.Create(requestName, container, "callbackRequest");


            request.SetValue("callbackRequestName", model.Name);
            request.SetValue("callbackRequestEmail", model.Email);
            request.SetValue("callbackRequestPhone", model.Phone);
            request.SetValue("callbackRequestOption", model.SelectedOption);

            var saveResult = _contentService.Save(request);

            return saveResult.Success;
        }
        catch(Exception ex) 
        {
            return false;
        }

    }
    public bool SaveQuestionRequest(QuestionFormViewmodel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "formSubmissons");
            if (container == null)
            {
                return false;
            }

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} -  {model.Name}";
            var request = _contentService.Create(requestName, container, "questionRequest");


            request.SetValue("questionRequestName", model.Name);
            request.SetValue("questionRequestEmail", model.Email);
            request.SetValue("questionRequestQuestion", model.Question);

            var saveResult = _contentService.Save(request);

            return saveResult.Success;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public bool SaveEmailRequest(EmailFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "formSubmissons");
            if (container == null)
            {
                return false;
            }

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} -  {model.Email}";
            var request = _contentService.Create(requestName, container, "emailRequest");


            request.SetValue("emailRequestEmail", model.Email);

            var saveResult = _contentService.Save(request);

            return saveResult.Success;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
}
