// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public interface IFormValidationRule
{
    Guid Id { get; }
    string Name { get; }
    string Description { get; }
    string Icon { get; }
    bool Validate(FormValidationContext context);
}