// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Cache;
using Our.Umbraco.Forms.Validator.Core.Services;
using Umbraco.Forms.Core.Models;
using FormValueProvider = Our.Umbraco.Forms.Validator.Core.FormValueProvider;

namespace Our.Umbraco.Forms.Validator.Services;

public sealed class FormValidatorService : IFormValidatorService
{
    private readonly IFormValidationRuleCache _ruleCache;

    public FormValidatorService(IFormValidationRuleCache ruleCache)
    {
        _ruleCache = ruleCache;
    }

    public void Validate(Form form, HttpContext context, ModelStateDictionary modelState)
    {
        var collector = new FormValidationCollector();
        var provider = new FormValueProvider(form);
        
        var validationContext = new FormValidationContext(context.Request, collector, provider);

        var rules = _ruleCache.GetRulesFor(form);

        foreach (var rule in rules)
        {
            bool stopProcessing = rule.Validate(validationContext);
            
            if (stopProcessing) break;
        }
        
        UpdateModelState(modelState, collector);
    }

    private void UpdateModelState(ModelStateDictionary modelState, FormValidationCollector collector)
    {
        foreach (var error in collector.Errors)
        {
            modelState.AddModelError(error.Field.Id.ToString(), error.Message);
        }
    }
}