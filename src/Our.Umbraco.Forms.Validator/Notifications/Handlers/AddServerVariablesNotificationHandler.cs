// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Our.Umbraco.Forms.Validator.Controllers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Our.Umbraco.Forms.Validator.Notifications.Handlers;

public class AddServerVariablesNotificationHandler : INotificationHandler<ServerVariablesParsingNotification>
{
    private IActionContextAccessor _actionContextAccessor;
    private IUrlHelperFactory _urlHelperFactory;
    private UmbracoApiControllerTypeCollection _umbracoApiControllers;

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
        var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);

        notification.ServerVariables.Add("umbracoUrls", new Dictionary<string, object>()
        {
            {
                "formsValidatorRulesApiBaseUrl",
                urlHelper.GetUmbracoApiServiceBaseUrl<RuleController>(_umbracoApiControllers, method => method.GetAll())
            },
        });
    }
}