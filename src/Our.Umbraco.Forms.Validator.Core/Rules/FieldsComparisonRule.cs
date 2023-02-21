using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FieldsComparisonRule : FieldValidationRule
{
    public Guid CompareToFieldId { get; set; }
    
    public FieldsComparisonRule(FormValueProvider provider, FormValidationCollector collector) : base(provider, collector)
    {
        
    }

    public override bool Validate(Form form, FormValue field)
    {
        var compareTo = Provider.GetFormValue(CompareToFieldId);

        if (compareTo is null)
            return false;
        
        return Validate(form, field, compareTo);
    }
    
    public abstract bool Validate(Form form, FormValue current, FormValue compare);
}