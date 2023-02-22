using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules;

public class FieldsEqual : FieldsComparisonRule
{
    public FieldsEqual(Form form, FieldsComparisonRuleSetting setting) : base(form, setting)
    {
    }

    public override bool Validate(FormValue current, FormValue compare, FormValidationContext context)
    {
        if (!string.Equals(current.Value, compare.Value))
        {
            context.Collector.AddValidationError(current, "Values do not match");
        }

        return false;
    }
}