// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Http;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core;

public sealed class FormValidationContext
{
    public FormValidationContext(
        Form form,
        IFormValidationSetting setting,
        HttpRequest request,
        FormValueProvider provider,
        FormValidationCollector collector)
    {
        Form = form;
        Setting = setting;
        Request = request;
        Provider = provider;
        Collector = collector;
    }

    public Form Form { get; }
    
    public IFormValidationSetting Setting { get; }
    
    public HttpRequest Request { get; }

    public FormValidationCollector Collector { get; }

    public FormValueProvider Provider { get; }
}