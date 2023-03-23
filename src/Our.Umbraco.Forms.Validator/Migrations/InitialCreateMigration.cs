// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.Extensions.Logging;
using Our.Umbraco.Forms.Validator.Infrastructure;
using Umbraco.Cms.Infrastructure.Migrations;

namespace Our.Umbraco.Forms.Validator.Migrations;

public sealed class InitialCreateMigration : MigrationBase
{
    public InitialCreateMigration(IMigrationContext context) : base(context)
    {
    }

    protected override void Migrate()
    {
        Logger.LogDebug("Running migration {name}", nameof(InitialCreateMigration));

        if (TableExists(Constants.SettingsTableName))
        {
            Logger.LogDebug("Table {name} already exists", Constants.SettingsTableName);
            return;
        }

        Create.Table<FormValidationSettingSchema>().Do();
        
        Logger.LogDebug("Table {name} created", Constants.SettingsTableName);
    }
}