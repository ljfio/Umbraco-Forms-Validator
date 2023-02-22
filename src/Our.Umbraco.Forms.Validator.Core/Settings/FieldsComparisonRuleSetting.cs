using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
public class FieldsComparisonRuleSetting : FieldValidationRuleSetting
{
    [DataMember]
    public Guid CompareToFieldId { get; set; }
}