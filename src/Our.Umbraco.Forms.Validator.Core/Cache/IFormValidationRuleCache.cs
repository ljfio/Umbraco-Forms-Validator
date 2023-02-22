// Copyright (c) 2023 Luke Fisher
// Licensed under the Apache License, Version 2.0.

using Our.Umbraco.Forms.Validator.Core.Rules;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Cache;

public interface IFormValidationRuleCache
{
    void AddRule(Form form, IFormValidationRule rule);
    IEnumerable<IFormValidationRule> GetRulesFor(Form form);
}