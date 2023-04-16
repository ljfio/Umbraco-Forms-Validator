// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules.FieldValidation;

public class FieldEqual : FieldValidationRule
{
    public FieldEqual() 
    {
        Id = new Guid("15C72055-3462-4D11-B45C-DE66CD28CF55");
        Name = "Equal to Value";
        Description = "Fails validation if this field is not equal to value";
        Icon = "icon-equals";
    }

    public override bool Validate(FormValue value, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}