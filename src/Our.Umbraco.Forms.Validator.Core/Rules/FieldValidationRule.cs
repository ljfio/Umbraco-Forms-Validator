using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldValidationRule : FormValidationRule, IFormValidationRule
{
    public FieldValidationRule(Form form, FieldValidationRuleSetting setting) : base(form, setting)
    {
        FieldId = setting.FieldId;
    }
    
    public Guid FieldId { get; }

    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        var field = context.Provider.GetFormValue(context.Request, FieldId);

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