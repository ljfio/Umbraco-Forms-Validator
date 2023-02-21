using Microsoft.AspNetCore.Mvc.ModelBinding;
using Umbraco.Forms.Core.Models;
using FormValueProvider = Our.Umbraco.Forms.Validator.Core.FormValueProvider;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldValidationRule
{
    public FieldValidationRule(FormValueProvider provider, FormValidationCollector collector)
    {
        Provider = provider;
        Collector = collector;
    }

    protected FormValueProvider Provider { get; }
    
    protected FormValidationCollector Collector { get; }
    
    public abstract bool Validate(FormFieldValue field);
}