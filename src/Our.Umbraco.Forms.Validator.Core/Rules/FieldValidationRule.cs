// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldValidationRule : FormValidationRule, IFormValidationRule
{
    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        if (context.Setting is not FieldValidationSetting setting)
            throw new InvalidOperationException();
        
        var field = context.Provider.GetFormValue(context.Request, setting.FieldId);

        if (field is null)
            return false;

        return Validate(field, context);
    }

    public override bool Validate(FormValidationContext context)
    {
        throw new InvalidOperationException();
    }

    public abstract bool Validate(FormValue value, FormValidationContext context);
}