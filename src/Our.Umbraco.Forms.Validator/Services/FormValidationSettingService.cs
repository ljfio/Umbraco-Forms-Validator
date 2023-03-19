// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Collections.ObjectModel;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Services;

public sealed class FormValidationSettingService : IFormValidationSettingService
{
    private readonly FormValidationRuleCollection _rules;
    private readonly IDictionary<Guid, IList<IFormValidationRuleWithSetting>> _cache;

    public FormValidationSettingService(FormValidationRuleCollection rules)
    {
        _rules = rules;
        _cache = new Dictionary<Guid, IList<IFormValidationRuleWithSetting>>();
    }

    public void Add(IFormValidationSetting setting)
    {
        var rule = _rules[setting.RuleId];

        if (!_cache.ContainsKey(setting.FormId))
        {
            _cache.Add(setting.FormId, new List<IFormValidationRuleWithSetting>());
        }

        var rules = _cache[setting.FormId];

        rules.Add(new FormValidationRuleWithSetting(rule, setting));
    }

    public IEnumerable<IFormValidationRuleWithSetting> RulesFor(Form form)
    {
        if (_cache.ContainsKey(form.Id))
        {
            return new ReadOnlyCollection<IFormValidationRuleWithSetting>(_cache[form.Id]);
        }

        return Enumerable.Empty<IFormValidationRuleWithSetting>();
    }
}