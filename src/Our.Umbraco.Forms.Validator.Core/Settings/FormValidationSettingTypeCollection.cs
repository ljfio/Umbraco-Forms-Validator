// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Composing;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

public class FormValidationSettingTypeCollection : BuilderCollectionBase<Type>
{
    public FormValidationSettingTypeCollection(Func<IEnumerable<Type>> items) : base(items)
    {
    }

    public Type this[string name]
    {
        get
        {
            var type = this.SingleOrDefault(t => t.Name == name);

            if (type is null)
                throw new KeyNotFoundException($"Cannot find setting type with name {name}");

            return type;
        }
    }
}