// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FormValidationRule : IFormValidationRule
{
    public Guid Id { get; protected init; }

    public string Name { get; protected init; }

    public string Description { get; protected init; }

    public string Icon { get; protected init; }

    public Type SettingType { get; protected init; } = typeof(FormValidationSetting);
    
    void IFormValidationRule.Validate(FormValidationContext context)
    {
        Validate(context);
    }

    public abstract void Validate(FormValidationContext context);
}