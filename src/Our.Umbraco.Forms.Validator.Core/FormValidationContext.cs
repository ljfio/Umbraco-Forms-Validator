// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Http;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core;

public sealed class FormValidationContext
{
    public FormValidationContext(
        Form form,
        IFormValidationRuleSetting setting,
        HttpRequest request,
        FormValidationCollector collector,
        FormValueProvider provider)
    {
        Form = form;
        Setting = setting;
        Request = request;
        Collector = collector;
        Provider = provider;
    }

    public Form Form { get; }
    
    public IFormValidationRuleSetting Setting { get; }
    
    public HttpRequest Request { get; }

    public FormValidationCollector Collector { get; }

    public FormValueProvider Provider { get; }
}