// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
public class FieldValidationRuleSetting : ValidationRuleSettingBase
{
    [DataMember]
    public string? Value { get; set; }
}