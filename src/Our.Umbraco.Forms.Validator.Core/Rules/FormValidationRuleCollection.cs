// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Composing;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public class FormValidationRuleCollection : BuilderCollectionBase<FormValidationRule>
{
    public FormValidationRuleCollection(Func<IEnumerable<FormValidationRule>> items) : base(items)
    {
    }

    public FormValidationRule this[Guid guid]
    {
        get
        {
            var rule = this.SingleOrDefault(r => r.Id == guid);

            if (rule is null) 
                throw new KeyNotFoundException($"Cannot find validation rule with the GUID {guid}");
            
            return rule;
        }
    }
}