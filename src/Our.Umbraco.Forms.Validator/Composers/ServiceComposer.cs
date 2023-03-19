// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.Extensions.DependencyInjection;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Services;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.Forms.Validator.Composers;

public class ServiceComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services
            .AddSingleton<IFormValidationSettingService, FormValidationSettingService>()
            .AddSingleton<IFormValidatorService, FormValidatorService>();
    }
}