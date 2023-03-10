// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Cache;

public interface IFormValidationRuleCache
{
    void Add(IFormValidationSetting setting);
    IEnumerable<IFormValidationRuleWithSetting> RulesFor(Form form);
}