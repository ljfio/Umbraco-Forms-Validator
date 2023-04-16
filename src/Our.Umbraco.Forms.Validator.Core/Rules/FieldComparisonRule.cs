// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldComparisonRule : FormValidationRule, IFormValidationRule
{
    protected FieldComparisonRule()
    {
        SettingType = typeof(FieldComparisonSetting);
    }

    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        if (context.Setting is not FieldComparisonSetting setting)
            throw new InvalidOperationException();
        
        var current = context.Provider.GetFormValue(setting.FieldId);
        var compare = context.Provider.GetFormValue(setting.CompareToFieldId);

        if (current is null || compare is null)
            return false;

        return Validate(current, compare, context);
    }

    public override bool Validate(FormValidationContext context)
    {
        throw new InvalidOperationException();
    }

    public abstract bool Validate(FormValue current, FormValue compare, FormValidationContext context);
}