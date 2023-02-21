using Microsoft.AspNetCore.Http;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldsComparisonRule : FieldValidationRule, IFormValidationRule
{
    public FieldsComparisonRule(Form form, FormValueProvider provider) : base(form, provider)
    {
    }

    public Guid CompareToFieldId { get; set; }

    bool IFormValidationRule.Validate(HttpRequest request, FormValidationCollector collector)
    {
        var current = Provider.GetFormValue(request, FieldId);
        var compare = Provider.GetFormValue(request, CompareToFieldId);

        if (current is null || compare is null)
            return false;

        return Validate(current, compare, collector);
    }

    public override bool Validate(FormValue value, FormValidationCollector collector)
    {
        throw new InvalidOperationException();
    }

    public abstract bool Validate(FormValue current, FormValue compare, FormValidationCollector collector);
}