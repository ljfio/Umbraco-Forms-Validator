// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FormValidationRule : IFormValidationRule
{
    public FormValidationRule(Form form, IValidationRuleSetting setting)
    {
        Form = form;
        Setting = setting;
    }
    
    public Guid Id { get; protected init; }

    public string Name { get; protected init; }

    public string Description { get; protected init; }

    protected Form Form { get; }

    protected IValidationRuleSetting Setting { get; }

    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        return Validate(context);
    }

    public abstract bool Validate(FormValidationContext context);
}