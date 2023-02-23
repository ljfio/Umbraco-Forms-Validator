// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Rules;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.Forms.Validator.Core.Extensions;

public static class UmbracoBuilderExtensions
{
    public static FormValidationRuleCollectionBuilder FormValidationRules(this IUmbracoBuilder builder) =>
        builder.WithCollectionBuilder<FormValidationRuleCollectionBuilder>();
}