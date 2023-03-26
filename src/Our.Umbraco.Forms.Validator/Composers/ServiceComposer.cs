// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.Extensions.DependencyInjection;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Infrastructure;
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
            .AddSingleton<IFormValidationSettingFactory, FormValidationSettingFactory>()
            .AddSingleton<IFormValidationSettingRepository, FormValidationSettingRepository>()
            .AddSingleton<IFormValidationSettingService, FormValidationSettingService>()
            .AddSingleton<IFormValidatorServiceFactory, FormValidatorServiceFactory>()
            .AddSingleton<IFormValidatorService>(provider =>
            {
                var factory = provider.GetRequiredService<IFormValidatorServiceFactory>();
                return factory.Create();
            });
    }
}