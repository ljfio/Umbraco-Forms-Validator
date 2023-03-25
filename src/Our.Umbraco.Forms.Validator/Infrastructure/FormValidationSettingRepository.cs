// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Cms.Infrastructure.Scoping;

namespace Our.Umbraco.Forms.Validator.Infrastructure;

public sealed class FormValidationSettingRepository :  IFormValidationSettingRepository
{
    private readonly IScopeProvider _scopeProvider;
    private readonly IFormValidationSettingFactory _settingFactory;

    public FormValidationSettingRepository(
        IScopeProvider scopeProvider,
        IFormValidationSettingFactory settingFactory)
    {
        _scopeProvider = scopeProvider;
        _settingFactory = settingFactory;
    }

    public IFormValidationSetting Save(IFormValidationSetting setting)
    {
        using var scope = _scopeProvider.CreateScope();
        
        var row = scope.Database.Query<FormValidationSettingSchema>()
            .Where(s => s.Key == setting.Id)
            .SingleOrDefault();

        if (row is null)
        {
            row = new FormValidationSettingSchema
            {
                Key = Guid.NewGuid(),
                Type = setting.GetType().Name,
                Properties = JsonSerializer.Serialize(setting),
            };

            scope.Database.Insert(row);
        }
        else
        {
            scope.Database.Update(row);
        }

        scope.Complete();

        return _settingFactory.Create(row.Key, row.Type, row.Properties);
    }

    public IFormValidationSetting Load(Guid id)
    {
        using var scope = _scopeProvider.CreateScope();

        var row = scope.Database.SingleById<FormValidationSettingSchema>(id);

        scope.Complete();

        return _settingFactory.Create(row.Key, row.Type, row.Properties);
    }

    public IEnumerable<IFormValidationSetting> Load()
    {
        var list = new List<IFormValidationSetting>();

        using var scope = _scopeProvider.CreateScope();

        var rows = scope.Database.Fetch<FormValidationSettingSchema>();

        scope.Complete();

        foreach (var row in rows)
        {
            list.Add(_settingFactory.Create(row.Key, row.Type, row.Properties));
        }

        return list;
    }
}