// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
public class FieldValidationSetting : FormValidationSetting, IFieldValidationSetting
{
    [DataMember]
    [FormValidationSettingField(
        "Field", 
        Description = "The field to apply validation rule to",
        Alias = "field", 
        Type = FormValidationSettingFieldType.Field)]
    public Guid FieldId { get; set; }

    [DataMember]
    [FormValidationSettingField(
        "Value",
        Description = "The value to compare the field against",
        Alias = "value", 
        Type = FormValidationSettingFieldType.Value)]
    public string? Value { get; set; }

    [DataMember]
    [FormValidationSettingField(
        "Expected type", 
        Description = "Expected data type for comparison",
        Alias = "expectedDataType",
        Type = FormValidationSettingFieldType.DataType)]
    public Guid ExpectedDataTypeId { get; set; }
}