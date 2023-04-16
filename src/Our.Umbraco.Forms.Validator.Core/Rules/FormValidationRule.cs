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

    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        return Validate(context);
    }

    public abstract bool Validate(FormValidationContext context);
}