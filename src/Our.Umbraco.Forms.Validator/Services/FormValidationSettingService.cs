// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Collections.ObjectModel;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Infrastructure;
using Our.Umbraco.Forms.Validator.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Services;

public sealed class FormValidationSettingService : IFormValidationSettingService
{
    private readonly FormValidationRuleCollection _rules;
    private readonly IFormValidationSettingRepository _repository;

    private readonly IDictionary<Guid, IList<IFormValidationRuleWithSetting>> _cache;

    public FormValidationSettingService(
        FormValidationRuleCollection rules,
        IFormValidationSettingRepository repository)
    {
        _rules = rules;
        _repository = repository;

        _cache = new Dictionary<Guid, IList<IFormValidationRuleWithSetting>>();
    }

    public void Load()
    {
        var settings = _repository.Load();

        foreach (var setting in settings)
        {
            AddToCache(setting);
        }
    }

    public void Add(IFormValidationSetting setting)
    {
        var saved = _repository.Save(setting);
        
        AddToCache(saved);
    }

    public IEnumerable<IFormValidationRuleWithSetting> RulesFor(Form form)
    {
        if (_cache.ContainsKey(form.Id))
        {
            return new ReadOnlyCollection<IFormValidationRuleWithSetting>(_cache[form.Id]);
        }

        return Enumerable.Empty<IFormValidationRuleWithSetting>();
    }

    private void AddToCache(IFormValidationSetting setting)
    {
        var rule = _rules[setting.RuleId];

        var rules = GetCacheForForm(setting.FormId);

        var existing = rules.SingleOrDefault(r => r.Setting.Id == setting.Id);

        if (existing is not null)
        {
            rules.Remove(existing);
        }

        rules.Add(new FormValidationRuleWithSetting(rule, setting));
    }

    private IList<IFormValidationRuleWithSetting> GetCacheForForm(Guid id)
    {
        if (!_cache.ContainsKey(id))
        {
            _cache.Add(id, new List<IFormValidationRuleWithSetting>());
        }

        return _cache[id];
    }
}