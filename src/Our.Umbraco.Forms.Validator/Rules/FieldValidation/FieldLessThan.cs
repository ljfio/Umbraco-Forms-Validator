// Copyright (c) 2023 Luke Fisher
// Licensed under the Apache License, Version 2.0.

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules.FieldValidation;

public class FieldLessThan : FieldValidationRule
{
    public FieldLessThan(Form form, FieldValidationRuleSetting setting) : base(form, setting)
    {
    }

    public override bool Validate(FormValue value, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}