// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core;
using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Rules.FormValidation;

public class AllFieldsRequired : FormValidationRule
{
    public AllFieldsRequired()
    {
        Id = new Guid("9DFBE963-4570-41AB-8EC6-8004556BD39D");
        Name = "All Required";
        Description = "Fails validation if any field on the form is not set";
        Icon = "icon-asterisk";
    }

    public override bool Validate(FormValidationContext context)
    {
        throw new NotImplementedException();
    }
}