using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules;

public class FieldsEqual : FieldsComparisonRule
{
    public FieldsEqual(FormValueProvider provider, FormValidationCollector collector) : base(provider, collector)
    {
    }
    
    public override bool Validate(FormValue current, FormValue compare)
    {
        throw new NotImplementedException();
    }
}