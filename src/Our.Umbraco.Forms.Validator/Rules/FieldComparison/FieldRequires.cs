// Copyright (c) 2023 Luke Fisher
// Licensed under the Apache License, Version 2.0.

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules.FieldComparison;

public class FieldRequires : FieldComparisonRule
{
    public FieldRequires(Form form, FieldsComparisonRuleSetting setting) : base(form, setting)
    {
    }

    public override bool Validate(FormValue current, FormValue compare, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}