// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Extensions;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.Forms.Validator.Composers;

public class SettingsComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.FormValidationSettings()
            .Add<FormValidationSetting>()
            .Add<FieldValidationSetting>()
            .Add<FieldComparisonSetting>();
    }
}