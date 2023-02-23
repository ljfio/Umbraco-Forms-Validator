// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Composing;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public class FormValidationRuleCollectionBuilder : LazyCollectionBuilderBase<FormValidationRuleCollectionBuilder, FormValidationRuleCollection, FormValidationRule>
{
    protected override FormValidationRuleCollectionBuilder This => this;
}