// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Models;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.Forms.Validator.Controllers;

[PluginController("FormsValidator")]
public class RuleController : UmbracoAuthorizedJsonController
{
    private readonly FormValidationRuleCollection _ruleCollection;

    public RuleController(FormValidationRuleCollection ruleCollection)
    {
        _ruleCollection = ruleCollection;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var rules = _ruleCollection
            .Select(rule => new RuleModel
            {
                Id = rule.Id.ToString(),
                Name = rule.Name,
                Icon = rule.Icon,
                Description = rule.Description,
            });

        return Ok(rules);
    }
}