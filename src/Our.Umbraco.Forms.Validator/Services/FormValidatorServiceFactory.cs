// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Services;

namespace Our.Umbraco.Forms.Validator.Services;

public sealed class FormValidatorServiceFactory : IFormValidatorServiceFactory
{
    private readonly IFormValidationSettingService _settingService;

    public FormValidatorServiceFactory(IFormValidationSettingService settingService)
    {
        _settingService = settingService;
    }

    public IFormValidatorService Create()
    {
        // TODO: Ensure loaded instead of always load
        _settingService.Load();
        return new FormValidatorService(_settingService);
    }
}