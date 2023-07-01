// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Factories;
using Our.Umbraco.Forms.Validator.Models;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;
using Umbraco.Extensions;

namespace Our.Umbraco.Forms.Validator.Controllers;

[PluginController("FormsValidator")]
public class SettingController : UmbracoAuthorizedJsonController
{
    private readonly IFormValidationSettingService _settingService;
    private readonly IPersistedFormValidationSettingFactory _factory;
    private readonly IUmbracoMapper _umbracoMapper;

    public SettingController(
        IFormValidationSettingService settingService,
        IPersistedFormValidationSettingFactory factory,
        IUmbracoMapper umbracoMapper)
    {
        _settingService = settingService;
        _factory = factory;
        _umbracoMapper = umbracoMapper;
    }

    [HttpPost]
    public IActionResult Save(
        [FromQuery] Guid id,
        [FromBody] IEnumerable<SettingModel> settings)
    {
        var entities = settings
            .Select(setting => _factory.Create(setting.Id, id, setting.RuleId, setting.Values))
            .WhereNotNull()
            .ToList();

        foreach (var entity in entities)
        {
            _settingService.Save(entity);
        }

        return Ok();
    }

    [HttpGet]
    public IActionResult Get([FromQuery] Guid id)
    {
        var settings = _settingService.GetByForm(id);

        var mapped = settings
            .Select(setting => _umbracoMapper.Map<SettingModel>(setting))
            .ToList();

        return Ok(mapped);
    }
}