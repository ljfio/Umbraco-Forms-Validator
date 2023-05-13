// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Collections.ObjectModel;
using Our.Umbraco.Forms.Validator.Core.Extensions;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Persistence.Repositories;
using Our.Umbraco.Forms.Validator.Settings;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Services;

public sealed class FormValidationSettingService : IFormValidationSettingService
{
    private readonly FormValidationRuleCollection _rules;
    private readonly IScopeProvider _scopeProvider;
    private readonly IFormValidationSettingRepository _repository;

    private readonly IDictionary<Guid, IList<IFormValidationRuleWithSetting>> _cache;

    public FormValidationSettingService(
        FormValidationRuleCollection rules,
        IScopeProvider scopeProvider,
        IFormValidationSettingRepository repository)
    {
        _rules = rules;
        _scopeProvider = scopeProvider;
        _repository = repository;

        _cache = new Dictionary<Guid, IList<IFormValidationRuleWithSetting>>();
    }

    public void Load()
    {
        using var scope = _scopeProvider.CreateScope();
        
        var settings = _repository.Get(scope);

        foreach (var setting in settings)
        {
            AddToCache(setting);
        }
    }

    public void Add(IFormValidationSetting setting)
    {
        _repository.Save(setting);

        AddToCache(setting);
    }

    public IEnumerable<IFormValidationRuleWithSetting> RulesFor(Form form)
    {
        if (_cache.TryGetValue(form.Id, out var foundCache))
        {
            return new ReadOnlyCollection<IFormValidationRuleWithSetting>(foundCache);
        }
        
        return Enumerable.Empty<IFormValidationRuleWithSetting>();
    }
    
    private void AddToCache(IFormValidationSetting setting)
    {
        var rule = _rules[setting.RuleKey];

        var rules = GetCacheForForm(setting.FormKey);

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