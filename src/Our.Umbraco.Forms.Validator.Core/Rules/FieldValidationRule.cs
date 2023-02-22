using Microsoft.AspNetCore.Http;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldValidationRule : IFormValidationRule
{
    public FieldValidationRule(Form form, FieldValidationRuleSetting setting)
    {
        Form = form;
        Setting = setting;
        
        FieldId = setting.FieldId;
    }

    protected Form Form { get; }
    
    protected IValidationRuleSetting Setting { get; }

    public Guid FieldId { get; }

    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        var field = context.Provider.GetFormValue(context.Request, FieldId);

        if (field is null)
            return false;

        return Validate(field, context);
    }

    public abstract bool Validate(FormValue value, FormValidationContext context);
}