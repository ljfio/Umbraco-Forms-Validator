// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Composing;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

public class FormValidationSettingTypeCollection : BuilderCollectionBase<Type>
{
    public FormValidationSettingTypeCollection(Func<IEnumerable<Type>> items) : base(items)
    {
    }
}