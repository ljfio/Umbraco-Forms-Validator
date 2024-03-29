// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules.FieldValidation;

public class FieldLessThan : FieldValidationRule
{
    public FieldLessThan() 
    {
        Id = new Guid("163E3192-27EB-4B73-B114-8A324072454F");
        Name = "Less Than Value";
        Description = "Fails validation if this field is not less than value";
        Icon = "icon-less-than";
    }

    public override void Validate(FormValue value, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}