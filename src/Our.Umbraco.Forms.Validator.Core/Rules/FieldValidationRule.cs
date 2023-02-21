using Microsoft.AspNetCore.Mvc.ModelBinding;
using Our.Umbraco.Forms.Core;
using Umbraco.Forms.Core.Models;
using FormValueProvider = Our.Umbraco.Forms.Core.FormValueProvider;

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