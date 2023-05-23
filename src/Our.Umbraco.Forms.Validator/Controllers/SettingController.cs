// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Factories;
using Our.Umbraco.Forms.Validator.Models;
using Our.Umbraco.Forms.Validator.Persistence.Repositories;
using Our.Umbraco.Forms.Validator.Services;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;
using Umbraco.Extensions;

namespace Our.Umbraco.Forms.Validator.Controllers;

[PluginController("FormsValidator")]
public class SettingController : UmbracoAuthorizedJsonController
{
    private readonly IScopeProvider _scopeProvider;
    private readonly IFormValidationSettingRepository _repository;
    private readonly IPersistedFormValidationSettingFactory _factory;

    public SettingController(
        IScopeProvider scopeProvider,
        IFormValidationSettingRepository repository,
        IPersistedFormValidationSettingFactory factory)
    {
        _scopeProvider = scopeProvider;
        _repository = repository;
        _factory = factory;
    }

    [HttpPost]
    public IActionResult Save(
        [FromQuery] Guid id,
        [FromBody] IEnumerable<SettingModel> settings)
    {
        using var scope = _scopeProvider.CreateScope();

        foreach (var setting in settings)
        {
            var entity = _factory.Create(setting.Id, id, setting.RuleId, setting.Values);

            if (entity is null)
                continue;

            _repository.Save(entity);
        }

        scope.Complete();

        return Ok();
    }

    [HttpGet]
    public IActionResult Get([FromQuery] Guid id)
    {
        using var scope = _scopeProvider.CreateScope();

        var query = scope.SqlContext.Query<IFormValidationSetting>()
            .Where(setting => setting.FormKey == id);

        var entities = _repository.Get(query);

        var settings = entities
            .Select(entity => new SettingModel
            {
                Id = entity.Key,
                RuleId = entity.RuleKey,
                Values = GetValues(entity),
            })
            .ToList();

        scope.Complete();

        return Ok(settings);
    }

    private IDictionary<string, string?> GetValues(IFormValidationSetting entity)
    {
        var values = new Dictionary<string, string?>();

        var type = entity.GetType();

        foreach (var property in type.GetProperties())
        {
            var attribute = property.GetCustomAttribute<FormValidationSettingFieldAttribute>();

            if (attribute is null)
                continue;

            string alias = attribute.Alias ?? property.Name.ToFirstLowerInvariant();

            var value = property.GetValue(entity);

            values.Add(alias, value?.ToString());
        }

        return values;
    }
}