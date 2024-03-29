// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Manifest;

namespace Our.Umbraco.Forms.Validator.Backoffice;

public class PluginManifestFilter : IManifestFilter
{
    public void Filter(List<PackageManifest> manifests)
    {
        manifests.Add(new PackageManifest
        {
            PackageName = Package.Name,
            Version = Package.Version,
            Scripts = new[]
            {
                "/App_Plugins/FormsValidator/scripts/formsValidator.resource.js",
                "/App_Plugins/FormsValidator/scripts/formsValidatorEditor.controller.js",
                "/App_Plugins/FormsValidator/scripts/formsValidatorSettings.controller.js",
                "/App_Plugins/FormsValidator/scripts/formsValidatorRulePicker.controller.js",
                "/App_Plugins/FormsValidator/scripts/formsValidatorFieldPicker.controller.js",
            },
            BundleOptions = BundleOptions.None,
        });
    }
}