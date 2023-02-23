// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules.FieldValidation;

public class FieldGreaterThan : FieldValidationRule
{
    public FieldGreaterThan() 
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