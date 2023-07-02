// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Persistence.Dtos;

namespace Our.Umbraco.Forms.Validator.Factories;

public interface IFormValidationSettingFactory 
{
    FormValidationSettingDto FromEntity(IFormValidationSetting entity);
    IFormValidationSetting ToEntity(FormValidationSettingDto dto);
    
    IFormValidationSetting ToEntity(Guid key, Guid formKey, Guid ruleKey, string type, string definition);
    IFormValidationSetting ToEntity(Guid key, Guid formKey, Guid ruleKey, IDictionary<string, string?> values);
}