// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules.FieldComparison;

public class FieldLessThanOrEqual : FieldComparisonRule
{
    public FieldLessThanOrEqual(Form form, FieldsComparisonRuleSetting setting) : base(form, setting)
    {
        Id = new Guid("23B4A5F1-D42A-44CE-B1D2-362EC8454959");
        Name = "Less Than or Equal to Field";
        Description = "Fails validation if this field is not less or equal when compared";
    }

    public override bool Validate(FormValue current, FormValue compare, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}