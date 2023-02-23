// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
public class FieldComparisonSetting : FormValidationSetting
{
    [DataMember]
    public Guid FieldId { get; set; }
    
    [DataMember]
    public Guid CompareToFieldId { get; set; }
}