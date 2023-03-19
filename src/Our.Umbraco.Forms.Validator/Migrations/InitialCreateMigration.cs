// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

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
        if (!TableExists("FormValidationSetting"))
        {
            Create.Table<FormValidationSettingSchema>().Do();
        }
    }
}