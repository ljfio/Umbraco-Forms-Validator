// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

namespace Our.Umbraco.Forms.Validator.Core.Settings;

public interface IFormValidationSetting
{
    Guid Id { get; }
    
    Guid FormId { get; }
    
    Guid RuleId { get; }
    
    string? Message { get; }
    
    bool StopProcessing { get; }
}