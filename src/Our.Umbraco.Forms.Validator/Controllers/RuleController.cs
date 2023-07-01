// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Mvc;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Models;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.Forms.Validator.Controllers;

[PluginController("FormsValidator")]
public class RuleController : UmbracoAuthorizedJsonController
{
    private readonly FormValidationRuleCollection _ruleCollection;
    private readonly IUmbracoMapper _umbracoMapper;

    public RuleController(
        FormValidationRuleCollection ruleCollection,
        IUmbracoMapper umbracoMapper)
    {
        _ruleCollection = ruleCollection;
        _umbracoMapper = umbracoMapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var rules = _ruleCollection.ToList();

        var mapped = rules
            .Select(rule => _umbracoMapper.Map<RuleModel>(rule))
            .ToList();
        
        return Ok(mapped);
    }

}