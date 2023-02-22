// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Services;

public interface IFormValidatorService
{
    void Validate(Form form, HttpContext context, ModelStateDictionary modelState);
}