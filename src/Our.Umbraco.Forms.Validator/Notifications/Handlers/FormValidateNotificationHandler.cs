using Our.Umbraco.Forms.Validator.Services;
using Umbraco.Cms.Core.Events;
using Umbraco.Forms.Core.Services.Notifications;

namespace Our.Umbraco.Forms.Validator.Notifications.Handlers;

public class FormValidateNotificationHandler : INotificationHandler<FormValidateNotification>
{
    private readonly IFormValidatorService _formValidatorService;

    public FormValidateNotificationHandler(IFormValidatorService formValidatorService)
    {
        _formValidatorService = formValidatorService;
    }

    public void Handle(FormValidateNotification notification)
    {
        _formValidatorService.Validate(notification.Form, notification.Context, notification.ModelState);
    }
}