// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core;

public sealed class FormValue
{
    public FormValue(Field field, string? value)
    {
        Field = field;
        Value = value;
    }

    public Field Field { get; }

    public string? Value { get; }
}