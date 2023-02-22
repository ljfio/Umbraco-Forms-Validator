// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

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