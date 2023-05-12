// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.Extensions.Logging;
using Our.Umbraco.Forms.Validator.Persistence.Dtos;
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

        if (TableExists(FormValidationSettingDto.TableName))
        {
            Logger.LogDebug("Table {name} already exists", FormValidationSettingDto.TableName);
            return;
        }

        Create.Table<FormValidationSettingDto>().Do();
        
        Logger.LogDebug("Table {name} created", FormValidationSettingDto.TableName);
    }
}