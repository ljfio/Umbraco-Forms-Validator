// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Persistence.Dtos;

namespace Our.Umbraco.Forms.Validator.Services;

public interface IPersistedFormValidationSettingFactory : IFormValidationSettingFactory
{
    FormValidationSettingDto Create(IFormValidationSetting setting);
    IFormValidationSetting? Create(Guid key, Guid formKey, Guid ruleKey, IDictionary<string, string?> values);
}