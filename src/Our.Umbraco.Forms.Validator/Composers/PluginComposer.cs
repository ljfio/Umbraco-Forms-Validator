// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Backoffice;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.Forms.Validator.Composers;

public class PluginComposer: IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.ContentApps().Append<SettingContentApp>();
        builder.ManifestFilters().Append<PluginManifestFilter>();
    }
}