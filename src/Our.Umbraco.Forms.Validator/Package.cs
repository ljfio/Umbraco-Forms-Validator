// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics;
using System.Reflection;

namespace Our.Umbraco.Forms.Validator;

public sealed class Package
{
    public static string Name { get; } = "FormsValidator";

    public static string Version
    {
        get
        {
            var assembly = Assembly.GetExecutingAssembly();

            var fileVersion = FileVersionInfo.GetVersionInfo(assembly.Location);

            return fileVersion.ProductVersion ?? "0.0.0-dev";
        }
    }
}