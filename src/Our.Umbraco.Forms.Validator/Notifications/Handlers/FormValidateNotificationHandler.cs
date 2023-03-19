// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Services;
using Umbraco.Cms.Core.Events;
using Umbraco.Forms.Core.Services.Notifications;

namespace Our.Umbraco.Forms.Validator.Notifications.Handlers;

public class FormValidateNotificationHandler : INotificationHandler<FormValidateNotification>
{
    private readonly IFormValidatorService _validatorService;

    public FormValidateNotificationHandler(IFormValidatorService validatorService)
    {
        _validatorService = validatorService;
    }

    public void Handle(FormValidateNotification notification)
    {
        _validatorService.Validate(notification.Form, notification.Context, notification.ModelState);
    }
}