// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.Extensions.DependencyInjection;
using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Factories;
using Our.Umbraco.Forms.Validator.Persistence.Repositories;
using Our.Umbraco.Forms.Validator.Services;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.Forms.Validator.Composers;

[ComposeAfter(typeof(RulesComposer))]
[ComposeAfter(typeof(SettingsComposer))]
public class ServiceComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services
            .AddTransient<IPersistedFormValidationSettingFactory, FormValidationSettingFactory>()
            .AddTransient<IFormValidationSettingRepository, FormValidationSettingRepository>()
            .AddTransient<IFormValidationSettingService, FormValidationSettingService>()
            .AddTransient<IFormValidatorService, FormValidatorService>()
            .AddTransient<FormValidationRuleProvider>();
    }
}