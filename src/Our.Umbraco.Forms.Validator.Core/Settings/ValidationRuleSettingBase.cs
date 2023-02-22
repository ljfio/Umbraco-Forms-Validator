using System.Runtime.Serialization;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
[DataContract]
public abstract class ValidationRuleSettingBase : IValidationRuleSetting
{
    [DataMember]
    public Guid FieldId { get; set; }
    
    [DataMember]
    public string? Message { get; set; }
}