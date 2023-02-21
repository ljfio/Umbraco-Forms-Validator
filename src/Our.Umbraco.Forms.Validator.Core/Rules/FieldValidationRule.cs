using Microsoft.AspNetCore.Http;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldValidationRule : IFormValidationRule
{
    public FieldValidationRule(Form form)
    {
        Form = form;
    }

    protected Form Form { get; }

    public Guid FieldId { get; set; }
    
    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        var field = context.Provider.GetFormValue(context.Request, FieldId);

        if (field is null)
            return false;

        return Validate(field, context);
    }

    public abstract bool Validate(FormValue value, FormValidationContext context);
}