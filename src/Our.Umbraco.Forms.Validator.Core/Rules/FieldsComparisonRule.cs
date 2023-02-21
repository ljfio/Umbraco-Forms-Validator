using Our.Umbraco.Forms.Core;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldsComparisonRule : FieldValidationRule
{
    public string? CompareFieldAlias { get; set; }
    
    public FieldsComparisonRule(FormValueProvider provider, FormValidationCollector collector) : base(provider, collector)
    {
        
    }

    public override bool Validate(FormFieldValue field)
    {
        var compareTo = Provider.GetFormValue(CompareFieldAlias);

        if (compareTo is null)
            return false;
        
        return Validate(field, compareTo);
    }
    
    public abstract bool Validate(FormFieldValue current, FormFieldValue compare);
}