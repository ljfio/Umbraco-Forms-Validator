// Copyright (c) 2023 Luke Fisher
// Licensed under the Apache License, Version 2.0.

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

    protected Form Form { get; }

    protected IValidationRuleSetting Setting { get; }

    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        return Validate(context);
    }

    public abstract bool Validate(FormValidationContext context);
}