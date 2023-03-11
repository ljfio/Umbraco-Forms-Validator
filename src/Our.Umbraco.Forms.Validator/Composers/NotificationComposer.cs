// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Forms.Core.Services.Notifications;
using Our.Umbraco.Forms.Validator.Notifications.Handlers;
using Umbraco.Cms.Core.Notifications;

namespace Our.Umbraco.Forms.Validator.Composers;

public class NotificationComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddNotificationHandler<FormValidateNotification, FormValidateNotificationHandler>()
            .AddNotificationHandler<UmbracoApplicationStartingNotification, MigrateOnStartingNotificationHandler>();
    }
}