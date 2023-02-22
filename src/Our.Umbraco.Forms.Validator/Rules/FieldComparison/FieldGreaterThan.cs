using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Rules.FieldComparison;

public class FieldGreaterThan : FieldComparisonRule
{
    public FieldGreaterThan(Form form, FieldsComparisonRuleSetting setting) : base(form, setting)
    {
    }

    public override bool Validate(FormValue current, FormValue compare, FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}