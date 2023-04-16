// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules.FieldComparison;

public class FieldRequires : FieldComparisonRule
{
    public FieldRequires()
    {
        Id = new Guid("6C1E381B-87E0-4E86-8187-5E00C3572834");
        Name = "Requires Field";
        Description = "Fails validation if compared fields is not set";
        Icon = "icon-asterisk";
    }

    public override bool Validate(FormValue current, FormValue compare, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}