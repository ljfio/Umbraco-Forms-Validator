// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.Extensions.Logging;
using Our.Umbraco.Forms.Validator.Core.Extensions;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Our.Umbraco.Forms.Validator.Migrations;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Sync;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;
using Umbraco.Cms.Infrastructure.Scoping;

namespace Our.Umbraco.Forms.Validator.Notifications.Handlers;

public class MigrateOnStartingNotificationHandler : INotificationHandler<UmbracoApplicationStartingNotification>
{
    private readonly ILogger<MigrateOnStartingNotificationHandler> _logger;
    private readonly IRuntimeState _runtimeState;
    private readonly IScopeProvider _scopeProvider;
    private readonly IMigrationPlanExecutor _migrationPlanExecutor;
    private readonly IKeyValueService _keyValueService;

    public MigrateOnStartingNotificationHandler(
        ILogger<MigrateOnStartingNotificationHandler> logger,
        IRuntimeState runtimeState,
        IScopeProvider scopeProvider,
        IMigrationPlanExecutor migrationPlanExecutor,
        IKeyValueService keyValueService)
    {
        _logger = logger;
        _runtimeState = runtimeState;
        _scopeProvider = scopeProvider;
        _migrationPlanExecutor = migrationPlanExecutor;
        _keyValueService = keyValueService;
    }

    public void Handle(UmbracoApplicationStartingNotification notification)
    {
        if (_runtimeState.Level < RuntimeLevel.Run)
        {
            _logger.LogDebug("Unable to handle notification at runtime level {level}", _runtimeState.Level);
            return;
        }

        var migrationPlan = new MigrationPlan("FormsValidator");

        migrationPlan.From(string.Empty)
            .To<InitialCreateMigration>(nameof(InitialCreateMigration));

        var upgrader = new Upgrader(migrationPlan);

        upgrader.Execute(_migrationPlanExecutor, _scopeProvider, _keyValueService);
    }
}