// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using System.Reflection;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Umbraco.Cms.Core.Mapping;
using Umbraco.Extensions;

namespace Our.Umbraco.Forms.Validator.Models.Mapping;

public class RuleMapDefinition : IMapDefinition
{
    public void DefineMaps(IUmbracoMapper mapper)
    {
        mapper.Define<IFormValidationRule, RuleModel>((_, _) => new RuleModel(), Map);
    }

    private void Map(IFormValidationRule source, RuleModel target, MapperContext context)
    {
        target.Id = source.Id.ToString();
        target.Name = source.Name;
        target.Icon = source.Icon;
        target.Description = source.Description;
        target.SettingFields = GetFields(source.SettingType);
    }

    private IEnumerable<SettingFieldModel> GetFields(Type ruleSettingType)
    {
        var properties = ruleSettingType.GetProperties();

        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<FormValidationSettingFieldAttribute>();

            if (attribute is not null)
            {
                yield return new SettingFieldModel
                {
                    Name = attribute.Name,
                    Alias = attribute.Alias ?? property.Name.ToFirstLowerInvariant(),
                    Type = attribute.Type.ToString().ToFirstLowerInvariant(),
                    Description = attribute.Description
                };
            }
        }
    }
}