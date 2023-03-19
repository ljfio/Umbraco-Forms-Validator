// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Services;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Our.Umbraco.Forms.Validator.Notifications.Handlers;

public class LoadSettingsOnStartedHandler : INotificationHandler<UmbracoApplicationStartedNotification>
{
    private readonly IFormValidationSettingService _settingService;

    public LoadSettingsOnStartedHandler(IFormValidationSettingService settingService) 
    {
        _settingService = settingService;
    }

    public void Handle(UmbracoApplicationStartedNotification notification)
    {
        _settingService.Load();
    }
}