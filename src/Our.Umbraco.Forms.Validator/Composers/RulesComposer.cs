// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Extensions;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Our.Umbraco.Forms.Validator.Composers;

public class RulesComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.FormValidationRules()
            // Form Validation
            .Add<Rules.FormValidation.AllFieldsRequired>()
            // Field Validation
            .Add<Rules.FieldValidation.FieldGreaterThan>()
            .Add<Rules.FieldValidation.FieldGreaterThanOrEqual>()
            .Add<Rules.FieldValidation.FieldLessThan>()
            .Add<Rules.FieldValidation.FieldLessThanOrEqual>()
            .Add<Rules.FieldValidation.FieldRegex>()
            .Add<Rules.FieldValidation.FieldRequired>()
            // Field Comparison
            .Add<Rules.FieldComparison.FieldEqual>()
            .Add<Rules.FieldComparison.FieldGreaterThan>()
            .Add<Rules.FieldComparison.FieldGreaterThanOrEqual>()
            .Add<Rules.FieldComparison.FieldLessThan>()
            .Add<Rules.FieldComparison.FieldLessThanOrEqual>()
            .Add<Rules.FieldComparison.FieldRequires>()
            .Add<Rules.FieldValidation.FieldEqual>();
    }
}