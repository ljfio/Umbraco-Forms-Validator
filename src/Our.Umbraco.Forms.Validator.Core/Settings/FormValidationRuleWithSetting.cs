// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

public sealed class FormValidationRuleWithSetting : IFormValidationRuleWithSetting
{
    public FormValidationRuleWithSetting(IFormValidationRule rule, IFormValidationSetting setting)
    {
        Rule = rule;
        Setting = setting;
    }

    public IFormValidationRule Rule { get; }
    
    public IFormValidationSetting Setting { get; }
}