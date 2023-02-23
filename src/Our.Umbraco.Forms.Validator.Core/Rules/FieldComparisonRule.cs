// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldComparisonRule : FieldValidationRule, IFormValidationRule
{
    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        if (context.Setting is not FieldComparisonSetting setting)
            throw new InvalidOperationException();
        
        var current = context.Provider.GetFormValue(context.Request, setting.FieldId);
        var compare = context.Provider.GetFormValue(context.Request, setting.CompareToFieldId);

        if (current is null || compare is null)
            return false;

        return Validate(current, compare, context);
    }

    public override bool Validate(FormValue value, FormValidationContext context)
    {
        throw new InvalidOperationException();
    }

    public abstract bool Validate(FormValue current, FormValue compare, FormValidationContext context);
}