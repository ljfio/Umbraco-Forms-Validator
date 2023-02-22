// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core;

public sealed class FormValidationError
{
    public FormValidationError(Field field, string message)
    {
        Field = field;
        Message = message;
    }

    public Field Field { get; }
    
    public string Message { get; }
}