// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules.FieldComparison;

public class FieldEqual : FieldComparisonRule
{
    public FieldEqual(Form form, FieldsComparisonRuleSetting setting) : base(form, setting)
    {
        Id = new Guid("BCB7C977-639B-4821-A29E-E4D7A492136B");
        Name = "Equal to Field";
        Description = "Fails validation if this field is not equal when compared";
    }

    public override bool Validate(FormValue current, FormValue compare, FormValidationContext context)
    {
        if (!string.Equals(current.Value, compare.Value))
        {
            context.Collector.AddValidationError(current, "Values do not match");
        }

        return false;
    }
}