// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Models;

[DataContract]
public class SettingModel
{
    [DataMember(Name = "id")]
    public Guid Id { get; set; }

    [DataMember(Name = "rule")]
    public Guid RuleId { get; set; }

    [DataMember(Name = "values")]
    public IDictionary<string, string?> Values { get; set; } = new Dictionary<string, string?>();
}