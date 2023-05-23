// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Composing;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public class FormValidationRuleCollection : BuilderCollectionBase<IFormValidationRule>
{
    public FormValidationRuleCollection(Func<IEnumerable<IFormValidationRule>> items) : base(items)
    {
    }

    public IFormValidationRule this[Guid guid]
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