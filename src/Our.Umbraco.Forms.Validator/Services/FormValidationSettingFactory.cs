// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Reflection;
using Newtonsoft.Json;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Persistence.Dtos;
using Umbraco.Extensions;

namespace Our.Umbraco.Forms.Validator.Services;

public class FormValidationSettingFactory : IFormValidationSettingFactory, IPersistedFormValidationSettingFactory
{
    private readonly FormValidationSettingTypeCollection _types;
    private readonly FormValidationRuleCollection _rules;

    public FormValidationSettingFactory(
        FormValidationSettingTypeCollection types,
        FormValidationRuleCollection rules)
    {
        _types = types;
        _rules = rules;
    }

    public IFormValidationSetting Create(Guid key, Guid formKey, Guid ruleKey, string type, string definition)
    {
        var validType = _types[type];

        if (JsonConvert.DeserializeObject(definition, validType) is not IFormValidationSetting setting)
            throw new InvalidOperationException();

        AssociateIdentities(setting, key, formKey, ruleKey);

        return setting;
    }

    public IFormValidationSetting? Create(Guid key, Guid formKey, Guid ruleKey, IDictionary<string, string?> values)
    {
        var rule = _rules[ruleKey];

        if (Activator.CreateInstance(rule.SettingType) is not IFormValidationSetting setting)
            return null;

        AssociateIdentities(setting, key, formKey, ruleKey);

        foreach (var property in rule.SettingType.GetProperties())
        {
            var attribute = property.GetCustomAttribute<FormValidationSettingFieldAttribute>();

            if (attribute is null)
                continue;

            string alias = attribute.Alias ?? property.Name.ToFirstLowerInvariant();

            if (!values.ContainsKey(alias))
                continue;

            var value = values[alias] is not null ? ParseValue(attribute.Type, values[alias]!) : null;

            property.SetValue(setting, value);
        }

        return setting;
    }

    private void AssociateIdentities(IFormValidationSetting setting, Guid key, Guid formKey, Guid ruleKey)
    {
        var type = setting.GetType();

        var keyProperty = type.GetProperty(nameof(IFormValidationSetting.Key));
        keyProperty?.SetValue(setting, key);

        var formProperty = type.GetProperty(nameof(IFormValidationSetting.FormKey));
        formProperty?.SetValue(setting, formKey);

        var ruleProperty = type.GetProperty(nameof(IFormValidationSetting.RuleKey));
        ruleProperty?.SetValue(setting, ruleKey);
    }

    private object? ParseValue(FormValidationSettingFieldType type, string value) => type switch
    {
        FormValidationSettingFieldType.Value => value,
        FormValidationSettingFieldType.Field => Guid.Parse(value),
        FormValidationSettingFieldType.DataType => Guid.Empty,
        FormValidationSettingFieldType.Toggle => bool.Parse(value),
        _ => throw new NotSupportedException("Field type is not supported"),
    };

    public FormValidationSettingDto Create(IFormValidationSetting setting)
    {
        var definition = JsonConvert.SerializeObject(setting);

        return new FormValidationSettingDto
        {
            Id = setting.Id,
            Key = setting.Key,
            FormKey = setting.FormKey,
            RuleKey = setting.RuleKey,
            Type = setting.GetType().Name,
            Definition = definition,
            CreateDate = setting.CreateDate,
            UpdateDate = setting.UpdateDate,
        };
    }
}