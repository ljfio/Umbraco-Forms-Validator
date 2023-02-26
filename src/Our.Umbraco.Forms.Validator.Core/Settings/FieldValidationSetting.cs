// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
public class FieldValidationSetting : FormValidationSetting, IFieldValidationSetting
{
    [DataMember]
    public Guid FieldId { get; set; }
    
    [DataMember]
    public string? Value { get; set; }
    
    [DataMember]
    public Guid ExpectedDataTypeId { get; set; }
}