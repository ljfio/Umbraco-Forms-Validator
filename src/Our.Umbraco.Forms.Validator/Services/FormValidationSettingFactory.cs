// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Persistence.Dtos;

namespace Our.Umbraco.Forms.Validator.Services;

public class FormValidationSettingFactory : IFormValidationSettingFactory, IPersistedFormValidationSettingFactory
{
    private readonly FormValidationSettingTypeCollection _types;

    public FormValidationSettingFactory(FormValidationSettingTypeCollection types)
    {
        _types = types;
    }

    public IFormValidationSetting Create(Guid key, string type, string definition)
    {
        var validType = _types[type];

        if (JsonSerializer.Deserialize(definition, validType) is not IFormValidationSetting setting)
            throw new InvalidOperationException();

        var property = validType.GetProperty(nameof(IFormValidationSetting.Id));
        property?.SetValue(setting, key);

        return setting;
    }

    public FormValidationSettingDto Create(IFormValidationSetting setting)
    {
        var definition = JsonSerializer.Serialize(setting);

        return new FormValidationSettingDto
        {
            Id = setting.Id,
            Key = setting.Key,
            Type = setting.GetType().Name,
            Definition = definition,
            CreateDate = setting.CreateDate,
            UpdateDate = setting.UpdateDate,
        };
    }
}