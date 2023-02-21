using Microsoft.AspNetCore.Http;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldValidationRule : IFormValidationRule
{
    public FieldValidationRule(Form form, FormValueProvider provider)
    {
        Form = form;
        Provider = provider;
    }

    protected Form Form { get; }
    
    protected FormValueProvider Provider { get; }

    public Guid FieldId { get; set; }
    
    bool IFormValidationRule.Validate(HttpRequest request, FormValidationCollector collector)
    {
        var field = Provider.GetFormValue(request, FieldId);

        if (field is null)
            return false;

        return Validate(field, collector);
    }

    public abstract bool Validate(FormValue value, FormValidationCollector collector);
}