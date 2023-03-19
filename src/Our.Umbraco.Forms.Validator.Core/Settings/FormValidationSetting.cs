// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.Serialization;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

[Serializable]
[DataContract]
public class FormValidationSetting : IFormValidationSetting
{
    public Guid Id { get; set; }

    [DataMember]
    public Guid FormId { get; set; }
    
    [DataMember]
    public Guid RuleId { get; set; }

    [DataMember]
    public string? Message { get; set; }

    [DataMember]
    public bool StopProcessing { get; set; }
}
