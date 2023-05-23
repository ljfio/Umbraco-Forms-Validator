// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;

namespace Our.Umbraco.Forms.Validator.Core.Factories;

public interface IFormValidationSettingFactory
{
    IFormValidationSetting Create(Guid key, Guid formKey, Guid ruleKey, string type, string definition);
}