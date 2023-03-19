// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Text.Json;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Core.Settings;

namespace Our.Umbraco.Forms.Validator.Services;

public class FormValidationSettingFactory : IFormValidationSettingFactory
{
    private readonly FormValidationSettingTypeCollection _types;

    public FormValidationSettingFactory(FormValidationSettingTypeCollection types)
    {
        _types = types;
    }

    public IFormValidationSetting Create(Guid id, string type, string properties)
    {
        var validType = _types[type];

        if (JsonSerializer.Deserialize(properties, validType) is not IFormValidationSetting setting)
            throw new InvalidOperationException();

        var property = validType.GetProperty(nameof(IFormValidationSetting.Id));
        property?.SetValue(setting, id);

        return setting;
    }
}