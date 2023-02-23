// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public abstract class FormValidationRule : IFormValidationRule
{
    public Guid Id { get; protected init; }

    public string Name { get; protected init; }

    public string Description { get; protected init; }

    bool IFormValidationRule.Validate(FormValidationContext context)
    {
        return Validate(context);
    }

    public abstract bool Validate(FormValidationContext context);
}