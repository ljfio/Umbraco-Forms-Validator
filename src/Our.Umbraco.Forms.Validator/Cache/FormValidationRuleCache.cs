// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Collections.ObjectModel;
using Our.Umbraco.Forms.Validator.Core.Cache;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Cache;

public class FormValidationRuleCache : IFormValidationRuleCache
{
    private FormValidationRuleCollection _validRules;

    private IDictionary<Guid, IList<IFormValidationRuleWithSetting>> _rulesCache;

    public FormValidationRuleCache(FormValidationRuleCollection rules)
    {
        _validRules = rules;
        _rulesCache = new Dictionary<Guid, IList<IFormValidationRuleWithSetting>>();
    }

    public void AddRule(Form form, Guid ruleId, IFormValidationSetting setting)
    {
        var rule = _validRules[ruleId];
        
        if (!_rulesCache.ContainsKey(form.Id))
        {
            _rulesCache.Add(form.Id, new List<IFormValidationRuleWithSetting>());
        }

        var rules = _rulesCache[form.Id];
        
        rules.Add(new FormValidationRuleWithSetting(rule, setting));
    }

    public IEnumerable<IFormValidationRuleWithSetting> GetRulesFor(Form form)
    {
        if (_rulesCache.ContainsKey(form.Id))
        {
            return new ReadOnlyCollection<IFormValidationRuleWithSetting>(_rulesCache[form.Id]);
        }

        return Enumerable.Empty<IFormValidationRuleWithSetting>();
    }
}