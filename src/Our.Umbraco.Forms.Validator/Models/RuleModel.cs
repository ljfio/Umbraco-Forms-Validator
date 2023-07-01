// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Models;

[DataContract]
public class RuleModel
{
    [DataMember(Name = "id")]
    public string Id { get; set; }
    
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "description")]
    public string Description { get; set; }
    
    [DataMember(Name = "icon")] 
    public string Icon { get; set; }
    
    [DataMember(Name = "settingFields")] 
    public IEnumerable<SettingFieldModel> SettingFields { get; set; }
}