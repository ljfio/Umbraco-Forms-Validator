using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules;

public class FieldsEqual : FieldsComparisonRule
{
    public FieldsEqual(Form form, FormValueProvider provider) : base(form, provider)
    {
    }

    public override bool Validate(FormValue current, FormValue compare, FormValidationCollector collector)
    {
        throw new NotImplementedException();
    }
}