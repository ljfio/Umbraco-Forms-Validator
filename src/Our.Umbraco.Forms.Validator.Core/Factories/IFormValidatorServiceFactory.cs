// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Services;

namespace Our.Umbraco.Forms.Validator.Core.Factories;

public interface IFormValidatorServiceFactory
{
    IFormValidatorService Create();
}