using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
public class FieldValidationRuleSetting : ValidationRuleSettingBase
{
    [DataMember]
    public string? Value { get; set; }
}