using Our.Umbraco.Forms.Validator.Notifications.Handlers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Forms.Core.Services.Notifications;

namespace Our.Umbraco.Forms.Validator.Composers;

public class DefaultComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddNotificationHandler<FormValidateNotification, FormValidateNotificationHandler>();
    }
}