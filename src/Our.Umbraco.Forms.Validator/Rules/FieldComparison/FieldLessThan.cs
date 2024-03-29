// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules.FieldComparison;

public class FieldLessThan : FieldComparisonRule
{
    public FieldLessThan()
    {
        Id = new Guid("F4753103-A31B-4E74-BCCA-35A8A5E0741A");
        Name = "Less Than Field";
        Description = "Fails validation if this field is not less when compared";
        Icon = "icon-less-than";
    }

    public override void Validate(FormValue current, FormValue compare, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}