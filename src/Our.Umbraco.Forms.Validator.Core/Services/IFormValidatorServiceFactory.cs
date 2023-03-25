// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

namespace Our.Umbraco.Forms.Validator.Core.Services;

public interface IFormValidatorServiceFactory
{
    IFormValidatorService Create();
}