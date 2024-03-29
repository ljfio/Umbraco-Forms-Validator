// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules.FieldValidation;

public class FieldRegex : FieldValidationRule
{
    public FieldRegex()
    {
        Id = new Guid("1ABD4D8B-1864-4F1A-A385-1D786A8A9F9F");
        Name = "Regex";
        Description = "Fails validation if this field does not match regular expression value";
        Icon = "icon-font-case";
    }

    public override void Validate(FormValue value, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}