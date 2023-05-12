// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Persistence.Dtos;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Infrastructure.Persistence.Mappers;

namespace Our.Umbraco.Forms.Validator.Persistence.Mappers;

[MapperFor(typeof(IFormValidationSetting))]
[MapperFor(typeof(FormValidationSetting))]
public class FormValidationSettingMapper : BaseMapper
{
    public FormValidationSettingMapper(Lazy<ISqlContext> sqlContext, MapperConfigurationStore maps) : base(sqlContext, maps)
    {
    }

    protected override void DefineMaps()
    {
        DefineMap<IFormValidationSetting, FormValidationSettingDto>(nameof(IFormValidationSetting.Id), nameof(FormValidationSettingDto.Id));
        DefineMap<IFormValidationSetting, FormValidationSettingDto>(nameof(IFormValidationSetting.Key), nameof(FormValidationSettingDto.Key));
        DefineMap<IFormValidationSetting, FormValidationSettingDto>(nameof(IFormValidationSetting.CreateDate), nameof(FormValidationSettingDto.CreateDate));
        DefineMap<IFormValidationSetting, FormValidationSettingDto>(nameof(IFormValidationSetting.UpdateDate), nameof(FormValidationSettingDto.UpdateDate));
    }
}