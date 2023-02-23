// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules.FieldValidation;

public class FieldRegex : FieldValidationRule
{
    public FieldRegex(Form form, FieldValidationRuleSetting setting) : base(form, setting)
    {
        Id = new Guid("1ABD4D8B-1864-4F1A-A385-1D786A8A9F9F");
        Name = "Regex";
        Description = "Fails validation if this field does not match regular expression value";
    }

    public override bool Validate(FormValue value, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}