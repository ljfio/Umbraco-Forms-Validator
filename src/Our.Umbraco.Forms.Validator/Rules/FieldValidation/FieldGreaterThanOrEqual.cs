// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules.FieldValidation;

public class FieldGreaterThanOrEqual : FieldValidationRule
{
    public FieldGreaterThanOrEqual(Form form, FieldValidationRuleSetting setting) : base(form, setting)
    {
        Id = new Guid("4B7BFFF2-552A-45CF-91C9-A9686F001052");
        Name = "Greater Than or Equal to Value";
        Description = "Fails validation if this field is not greater than or equal to value";
    }

    public override bool Validate(FormValue value, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}