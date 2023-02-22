using Microsoft.Extensions.DependencyInjection;
using Our.Umbraco.Forms.Validator.Cache;
using Our.Umbraco.Forms.Validator.Core.Cache;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Notifications.Handlers;
using Our.Umbraco.Forms.Validator.Services;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Forms.Core.Services.Notifications;

namespace Our.Umbraco.Forms.Validator.Composers;

public class DefaultComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        // Services
        builder.Services
            .AddSingleton<IFormValidationRuleCache, FormValidationRuleCache>()
            .AddSingleton<IFormValidatorService, FormValidatorService>();
        
        // Notifications
        builder.AddNotificationHandler<FormValidateNotification, FormValidateNotificationHandler>();
    }
}