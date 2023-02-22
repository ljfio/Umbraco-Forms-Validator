using Microsoft.AspNetCore.Http;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldComparisonRule : FieldValidationRule, IFormValidationRule
{
    public FieldComparisonRule(Form form, FieldsComparisonRuleSetting setting) : base(form, setting)
    {
        CompareToFieldId = setting.CompareToFieldId;
    }

    public Guid CompareToFieldId { get; }

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