using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules;

public class FieldsLessThan : FieldsComparisonRule
{
    public FieldsLessThan(FormValueProvider provider, FormValidationCollector collector) : base(provider, collector)
    {
    }
    
    public override bool Validate(Form form, FormValue current, FormValue compare)
    {
        throw new NotImplementedException();
    }
}