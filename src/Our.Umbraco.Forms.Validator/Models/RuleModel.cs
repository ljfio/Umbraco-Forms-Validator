// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Models;

[DataContract]
public class RuleModel
{
    [DataMember(Name = "id")]
    public string Id { get; init; }
    
    [DataMember(Name = "name")]
    public string Name { get; init; }

    [DataMember(Name = "description")]
    public string Description { get; init; }
    
    [DataMember(Name = "icon")] 
    public string Icon { get; init; }
}