// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using NPoco;
using Umbraco.Forms.Core.Persistence.Dtos;

namespace Our.Umbraco.Forms.Validator.Persistence.Dtos;

[TableName(TableName)]
[ExplicitColumns]
public sealed class FormValidationSettingDto : BaseDto
{
    public const string TableName = "FormValidationSetting";
    
    [Column(Name = nameof(Type))] 
    public string Type { get; set; }
}