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
            Scripts = new[]
            {
                "~/App_Plugins/FormsValidator/js/formsvalidatorsettings.controller.js"
            }
        });
    }
}