// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.Forms.Validator.Core.Services;

public interface IFormValidationSettingService : IService
{
    IEnumerable<IFormValidationSetting> Get();
    IFormValidationSetting? Get(Guid key);
    IEnumerable<IFormValidationSetting> GetByForm(Guid key);
    Attempt<OperationResult?> Save(IFormValidationSetting setting);
    Attempt<OperationResult?> Delete(IFormValidationSetting setting);
}