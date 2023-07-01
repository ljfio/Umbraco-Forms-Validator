// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Services;
using Umbraco.Forms.Core.Models;
using FormValueProvider = Our.Umbraco.Forms.Validator.Core.FormValueProvider;

namespace Our.Umbraco.Forms.Validator.Services;

public sealed class FormValidatorService : IFormValidatorService
{
    private readonly FormValidationRuleProvider _ruleProvider;

    public FormValidatorService(FormValidationRuleProvider ruleProvider)
    {
        _ruleProvider = ruleProvider;
    }

    public void Validate(Form form, HttpContext context, ModelStateDictionary modelState)
    {
        var collector = new FormValidationCollector();
        var provider = new FormValueProvider(form, context.Request);
        
        var rules = _ruleProvider.RulesFor(form);

        foreach (var rule in rules)
        {
            var validationContext = new FormValidationContext(form, rule.Setting, context.Request, provider, collector);
            
            rule.Rule.Validate(validationContext);
            
            if (!validationContext.IsValid && rule.Setting.StopProcessing) 
                break;
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