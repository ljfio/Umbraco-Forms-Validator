// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;
using Umbraco.Cms.Core.Models.Entities;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
[DataContract]
public class FormValidationSetting : EntityBase, IFormValidationSetting
{
    public Guid FormKey { get; set; }
    
    public Guid RuleKey { get; set; }

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
}
