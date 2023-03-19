// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;

namespace Our.Umbraco.Forms.Validator.Core.Services;

public interface IFormValidationSettingFactory
{
    IFormValidationSetting Create(Guid id, string type, string properties);
}