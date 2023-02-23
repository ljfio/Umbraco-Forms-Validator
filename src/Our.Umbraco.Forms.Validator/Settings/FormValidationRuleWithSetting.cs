// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;

namespace Our.Umbraco.Forms.Validator.Settings;

public class FormValidationRuleWithSetting : IFormValidationRuleWithSetting
{
    public FormValidationRuleWithSetting(IFormValidationRule rule, IFormValidationSetting setting)
    {
        Rule = rule;
        Setting = setting;
    }

    public IFormValidationRule Rule { get; }
    
    public IFormValidationSetting Setting { get; }
}