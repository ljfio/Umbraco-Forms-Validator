// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Factories;
using Our.Umbraco.Forms.Validator.Models;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.Forms.Validator.Controllers;

[PluginController("FormsValidator")]
public class SettingController : UmbracoAuthorizedJsonController
{
    private readonly IFormValidationSettingService _settingService;
    private readonly IFormValidationSettingFactory _factory;
    private readonly IUmbracoMapper _umbracoMapper;

    public SettingController(
        IFormValidationSettingService settingService,
        IFormValidationSettingFactory factory,
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
        var settingsToDelete = settings
            .Where(setting => setting.Deleted)
            .Select(setting => _factory.ToEntity(setting.Id, id, setting.RuleId, setting.Values))
            .ToList();

        foreach (var setting in settingsToDelete)
        {
            _settingService.Delete(setting);
        }
        
        var settingsToSave = settings
            .Where(setting => !setting.Deleted)
            .Select(setting => _factory.ToEntity(setting.Id, id, setting.RuleId, setting.Values))
            .ToList();

        foreach (var setting in settingsToSave)
        {
            _settingService.Save(setting);
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