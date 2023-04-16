// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[AttributeUsage(AttributeTargets.Property)]
public class FormValidationSettingFieldAttribute : Attribute
{
    public FormValidationSettingFieldAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public string? Alias { get; init; }

    public string? Description { get; init; }
    
    public FormValidationSettingFieldType Type { get; init; }
}