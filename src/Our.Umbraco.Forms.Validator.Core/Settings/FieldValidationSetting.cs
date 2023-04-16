// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
public class FieldValidationSetting : FormValidationSetting, IFieldValidationSetting
{
    [DataMember]
    [FormValidationSettingField("Field", Alias = "field", Type = FormValidationSettingFieldType.Field)]
    public Guid FieldId { get; set; }
    
    [DataMember]
    [FormValidationSettingField("Value", Alias = "value", Type = FormValidationSettingFieldType.Value)]
    public string? Value { get; set; }
    
    [DataMember]
    [FormValidationSettingField("Expected type", Alias = "expectedDataType", Type = FormValidationSettingFieldType.DataType)]
    public Guid ExpectedDataTypeId { get; set; }
}