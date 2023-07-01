// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Cms.Core.Cache;
using Umbraco.Extensions;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core;

public sealed class FormValidationRuleProvider
{
    private readonly FormValidationRuleCollection _rules;
    private readonly IFormValidationSettingService _settingService;
    private readonly IAppPolicyCache _cache;

    public FormValidationRuleProvider(
        FormValidationRuleCollection rules,
        IFormValidationSettingService settingService,
        AppCaches appCaches)
    {
        _rules = rules;
        _settingService = settingService;
        
        _cache = appCaches.RuntimeCache;
    }

    public IEnumerable<IFormValidationRuleWithSetting> RulesFor(Form form)
    {
        return _cache
            .GetCacheItem($"{nameof(FormValidationRuleProvider)}_Form_{form.Id}", () => GetRulesFromDatabase(form.Id))
            .EmptyNull();
    }

    public void InvalidateCache(Form form)
    {
        _cache.Clear($"{nameof(FormValidationRuleProvider)}_Form_{form.Id}");
    }

    private IEnumerable<IFormValidationRuleWithSetting> GetRulesFromDatabase(Guid key)
    {
        var ruleWithSettings = new List<IFormValidationRuleWithSetting>();
        
        var settings = _settingService.GetByForm(key);

        foreach (var setting in settings)
        {
            var rule = _rules[setting.RuleKey];
            
            ruleWithSettings.Add(new FormValidationRuleWithSetting(rule, setting));
        }

        return ruleWithSettings;
    }
}