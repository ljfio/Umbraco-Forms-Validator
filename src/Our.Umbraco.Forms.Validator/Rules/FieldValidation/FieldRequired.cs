// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules.FieldValidation;

public class FieldRequired : FieldValidationRule
{
    public FieldRequired(Form form, FieldValidationRuleSetting setting) : base(form, setting)
    {
        Id = new Guid("458890B0-591E-4135-A951-B26FB0A8E6F3");
        Name = "Required";
        Description = "Fails validation if this field is not set";
    }

    public override bool Validate(FormValue value, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}