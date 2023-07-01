// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Reflection;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Extensions;

namespace Our.Umbraco.Forms.Validator.Models.Mapping;

public class SettingMapDefinition : IMapDefinition
{
    public void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<IFormValidationSetting, SettingModel>((_, _) => new SettingModel(), Map);
    }

    private void Map(IFormValidationSetting source, SettingModel target, MapperContext context)
    {
        target.Id = source.Key;
        target.RuleId = source.RuleKey;
        target.Values = GetValues(source);
    }

    private IDictionary<string, string?> GetValues(IFormValidationSetting entity)
    {
        var values = new Dictionary<string, string?>();

        var type = entity.GetType();

        foreach (var property in type.GetProperties())
        {
            var attribute = property.GetCustomAttribute<FormValidationSettingFieldAttribute>();

            if (attribute is null)
                continue;

            string alias = attribute.Alias ?? property.Name.ToFirstLowerInvariant();

            var value = property.GetValue(entity);

            values.Add(alias, value?.ToString());
        }

        return values;
    }
}