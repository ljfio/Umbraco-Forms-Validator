// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Models;

[DataContract]
public class SettingModel
{
    [DataMember(Name = "id")]
    public Guid Id { get; init; }

    [DataMember(Name = "rule")]
    public Guid RuleId { get; init; }

    [DataMember(Name = "values")]
    public IDictionary<string, object?> Values { get; init; } = new Dictionary<string, object?>();
}