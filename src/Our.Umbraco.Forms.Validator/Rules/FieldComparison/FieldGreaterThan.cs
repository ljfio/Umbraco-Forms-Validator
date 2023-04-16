// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules.FieldComparison;

public class FieldGreaterThan : FieldComparisonRule
{
    public FieldGreaterThan()
    {
        Id = new Guid("6098187A-CBE1-4FD8-8EE6-D664F5B5176C");
        Name = "Greater Than Field";
        Description = "Fails validation if this field is not greater when compared";
        Icon = "icon-greater-than";
    }

    public override bool Validate(FormValue current, FormValue compare, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}