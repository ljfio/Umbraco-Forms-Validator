// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldValidationRule : FormValidationRule, IFormValidationRule
{
    protected FieldValidationRule()
    {
        SettingType = typeof(FieldValidationSetting);
    }

    void IFormValidationRule.Validate(FormValidationContext context)
    {
        if (context.Setting is not FieldValidationSetting setting)
            throw new InvalidOperationException();
        
        var field = context.Provider.GetFormValue(setting.FieldId);

        if (field is null)
            return;

        Validate(field, context);
    }

    public override void Validate(FormValidationContext context)
    {
        throw new InvalidOperationException();
    }

    public abstract void Validate(FormValue value, FormValidationContext context);
}