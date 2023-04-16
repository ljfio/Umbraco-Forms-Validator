// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Models;

[DataContract]
public class SettingFieldModel
{
    [DataMember(Name = "name")]
    public string Name { get; init; }

    [DataMember(Name = "alias")]
    public string Alias { get; init; }

    [DataMember(Name = "type")]
    public string Type { get; init; }
}