// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

namespace Our.Umbraco.Forms.Validator.Core.Extensions;

public static class EnumExtensions
{
    public static bool IsAny(this Enum value, params Enum[] values)
    {
        return values.Contains(value);
    }
}