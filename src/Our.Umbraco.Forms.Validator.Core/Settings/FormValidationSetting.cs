// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
[DataContract]
public class FormValidationSetting : IFormValidationSetting
{
    public int Id { get; set; }
    
    public Guid Key { get; set; } = Guid.Empty;
    
    [DataMember]
    public Guid FormId { get; set; }
    
    [DataMember]
    public Guid RuleId { get; set; }

    [DataMember]
    [FormValidationSettingField(
        "Message",
        Description = "Custom validation error message",
        Alias = "message", 
        Type = FormValidationSettingFieldType.Value)]
    public string? Message { get; set; }

    [DataMember]
    [FormValidationSettingField(
        "Stop processing",
        Description = "Toggle if you want to stop processing validation rules on failure",
        Alias = "stopProcessing", 
        Type = FormValidationSettingFieldType.Toggle)]
    public bool StopProcessing { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool HasIdentity => Key != Guid.Empty;
    
    public object DeepClone()
    {
        throw new NotImplementedException();
    }

    public void ResetIdentity()
    {
        Id = default;
        Key = Guid.NewGuid();
    }
}
