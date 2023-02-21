using Microsoft.AspNetCore.Http;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldsComparisonRule : FieldValidationRule, IFormValidationRule
{
    public FieldsComparisonRule(Form form) : base(form)
    {
    }

    public Guid CompareToFieldId { get; set; }

    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        var current = context.Provider.GetFormValue(context.Request, FieldId);
        var compare = context.Provider.GetFormValue(context.Request, CompareToFieldId);

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