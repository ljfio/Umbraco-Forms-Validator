// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

public interface IFormValidationRuleWithSetting
{
    IFormValidationRule Rule { get; }

    IFormValidationSetting Setting { get; }
}