// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Composing;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

public class FormValidationSettingCollectionBuilder : TypeCollectionBuilderBase<FormValidationSettingCollectionBuilder, FormValidationSettingCollection, IFormValidationSetting>
{
    protected override FormValidationSettingCollectionBuilder This => this;
}