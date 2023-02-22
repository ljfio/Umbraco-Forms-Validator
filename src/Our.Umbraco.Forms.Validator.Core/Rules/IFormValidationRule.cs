// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public interface IFormValidationRule
{
    bool Validate(FormValidationContext context);
}