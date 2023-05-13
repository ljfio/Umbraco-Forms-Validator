// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Backoffice;
using Our.Umbraco.Forms.Validator.Persistence.Mappers;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;

namespace Our.Umbraco.Forms.Validator.Composers;

public class PluginComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.ContentApps()
            .Append<SettingContentApp>();

        builder.ManifestFilters()
            .Append<PluginManifestFilter>();

        builder.Mappers()?
            .Add<FormValidationSettingMapper>();
    }
}