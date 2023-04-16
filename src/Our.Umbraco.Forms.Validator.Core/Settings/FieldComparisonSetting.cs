// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
public class FieldComparisonSetting : FormValidationSetting, IFieldValidationSetting
{
    [DataMember]
    [FormValidationSettingField("Field", Alias = "field", Type = FormValidationSettingFieldType.Field)]
    public Guid FieldId { get; set; }

    [DataMember]
    [FormValidationSettingField("Compare to field", Alias = "compareToField", Type = FormValidationSettingFieldType.Field)]
    public Guid CompareToFieldId { get; set; }

    [DataMember]
    [FormValidationSettingField("Expected type", Alias = "expectedDataType", Type = FormValidationSettingFieldType.DataType)]
    public Guid ExpectedDataTypeId { get; set; }
}