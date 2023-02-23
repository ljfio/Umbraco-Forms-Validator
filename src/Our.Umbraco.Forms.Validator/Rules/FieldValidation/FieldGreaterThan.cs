// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules.FieldValidation;

public class FieldGreaterThan : FieldValidationRule
{
    public FieldGreaterThan(Form form, FieldValidationRuleSetting setting) : base(form, setting)
    {
        Id = new Guid("6684ABC4-609D-43A4-A780-10968FC8E9B3");
        Name = "Greater Than Value";
        Description = "Fails validation if this field is not greater than value";
    }

    public override bool Validate(FormValue value, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}