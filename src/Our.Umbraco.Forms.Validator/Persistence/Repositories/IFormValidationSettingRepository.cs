// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Cms.Core.Persistence;

namespace Our.Umbraco.Forms.Validator.Persistence.Repositories;

public interface IFormValidationSettingRepository : IReadWriteQueryRepository<Guid, IFormValidationSetting>
{
}