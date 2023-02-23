// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules.FieldComparison;

public class FieldGreaterThanOrEqual : FieldComparisonRule
{
    public FieldGreaterThanOrEqual(Form form, FieldsComparisonRuleSetting setting) : base(form, setting)
    {
        Id = new Guid("86F03315-8C25-4F81-AFDE-68ED333CD48F");
        Name = "Greater Than or Equal to Field";
        Description = "Fails validation if this field is not greater or equal when compared";
    }

    public override bool Validate(FormValue current, FormValue compare, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}