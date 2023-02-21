using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules;

public class FieldsLessThanOrEqual : FieldsComparisonRule
{
    public FieldsLessThanOrEqual(FormValueProvider provider, FormValidationCollector collector) : base(provider, collector)
    {
    }
    
    public override bool Validate(FormValue current, FormValue compare)
    {
        throw new NotImplementedException();
    }
}