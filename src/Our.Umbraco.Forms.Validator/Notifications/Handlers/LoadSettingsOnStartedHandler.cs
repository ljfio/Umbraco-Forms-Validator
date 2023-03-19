// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using NPoco;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Infrastructure;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Infrastructure.Scoping;

namespace Our.Umbraco.Forms.Validator.Notifications.Handlers;

public class LoadSettingsOnStartedHandler : INotificationHandler<UmbracoApplicationStartedNotification>
{
    private readonly IScopeProvider _scopeProvider;
    private readonly IFormValidationSettingService _settingService;
    private readonly IFormValidationSettingFactory _settingFactory;

    public LoadSettingsOnStartedHandler(
        IScopeProvider scopeProvider, 
        IFormValidationSettingService settingService, 
        IFormValidationSettingFactory settingFactory)
    {
        _scopeProvider = scopeProvider;
        _settingService = settingService;
        _settingFactory = settingFactory;
    }

    public void Handle(UmbracoApplicationStartedNotification notification)
    {
        using var scope = _scopeProvider.CreateScope();

        var rows = scope.Database.Fetch<FormValidationSettingSchema>();

        foreach (var row in rows)
        {
            var setting = _settingFactory.Create(row.Type, row.Properties);
            _settingService.Add(setting);
        }

        scope.Complete();
    }
}