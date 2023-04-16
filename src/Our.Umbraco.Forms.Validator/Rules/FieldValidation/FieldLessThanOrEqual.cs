// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules.FieldValidation;

public class FieldLessThanOrEqual : FieldValidationRule
{
    public FieldLessThanOrEqual()
    {
        Id = new Guid("2A38A3FC-6696-45DC-9BD1-BF5B0D5EA4A1");
        Name = "Less Than or Equal to Value";
        Description = "Fails validation if this field is not less than or equal to value";
        Icon = "icon-less-than-equal";
    }

    public override bool Validate(FormValue value, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}