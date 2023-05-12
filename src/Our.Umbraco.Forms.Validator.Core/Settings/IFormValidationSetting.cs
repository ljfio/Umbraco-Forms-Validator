// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Models.Entities;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

public interface IFormValidationSetting : IEntity
{
    Guid FormId { get; }
    
    Guid RuleId { get; }
    
    string? Message { get; }
    
    bool StopProcessing { get; }
}