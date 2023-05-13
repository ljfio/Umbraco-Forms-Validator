// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Our.Umbraco.Forms.Validator.Controllers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Our.Umbraco.Forms.Validator.Notifications.Handlers;

public class AddServerVariablesNotificationHandler : INotificationHandler<ServerVariablesParsingNotification>
{
    private readonly IActionContextAccessor _actionContextAccessor;
    private readonly IUrlHelperFactory _urlHelperFactory;
    private readonly UmbracoApiControllerTypeCollection _umbracoApiControllers;

    public AddServerVariablesNotificationHandler(
        IActionContextAccessor actionContextAccessor,
        IUrlHelperFactory urlHelperFactory,
        UmbracoApiControllerTypeCollection umbracoApiControllers)
    {
        _actionContextAccessor = actionContextAccessor;
        _urlHelperFactory = urlHelperFactory;
        _umbracoApiControllers = umbracoApiControllers;
    }

    public void Handle(ServerVariablesParsingNotification notification)
    {
        var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext!);

        if (notification.ServerVariables.TryGetValue("umbracoUrls", out var value) &&
            value is Dictionary<string, object> dictionary)
        {
            AddBaseUrlToServerVariables<RuleController>(urlHelper, dictionary, "formsValidatorRulesApiBaseUrl", "GetAll");
            AddBaseUrlToServerVariables<SettingController>(urlHelper, dictionary, "formsValidatorSettingsApiBaseUrl", "Save");
        }
    }

    private void AddBaseUrlToServerVariables<T>(
        IUrlHelper urlHelper,
        IDictionary<string, object> dictionary,
        string key,
        string actionName) where T : UmbracoApiController
    {
        string? url = urlHelper.GetUmbracoApiServiceBaseUrl<T>(_umbracoApiControllers, actionName);

        if (!string.IsNullOrEmpty(url))
        {
            dictionary.Add(key, url);
        }
    }
}