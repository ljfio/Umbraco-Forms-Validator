// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.Extensions.Logging;
using NPoco;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Factories;
using Our.Umbraco.Forms.Validator.Persistence.Dtos;
using Our.Umbraco.Forms.Validator.Services;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Persistence.Querying;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Infrastructure.Persistence.Querying;
using Umbraco.Cms.Infrastructure.Persistence.Repositories.Implement;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Extensions;

namespace Our.Umbraco.Forms.Validator.Persistence.Repositories;

internal sealed class FormValidationSettingRepository : EntityRepositoryBase<Guid, IFormValidationSetting>,
    IFormValidationSettingRepository
{
    private readonly IPersistedFormValidationSettingFactory _settingFactory;

    public FormValidationSettingRepository(
        IScopeAccessor scopeAccessor,
        AppCaches appCaches,
        ILogger<FormValidationSettingRepository> logger,
        IPersistedFormValidationSettingFactory settingFactory) : base(scopeAccessor, appCaches, logger)
    {
        _settingFactory = settingFactory;
    }

    /// <inheritdoc />
    protected override IFormValidationSetting? PerformGet(Guid key)
    {
        var query = GetBaseQuery(false)
            .Where<FormValidationSettingDto>(row => row.Key == key);

        var row = Database.SingleOrDefault<FormValidationSettingDto>(query);

        return _settingFactory.Create(row.Key, row.FormKey, row.RuleKey, row.Type, row.Definition);
    }

    /// <inheritdoc />
    protected override IEnumerable<IFormValidationSetting> PerformGetAll(params Guid[]? keys)
    {
        var query = SqlContext.Query<IFormValidationSetting>()
            .WhereIn(setting => setting.Key, keys);

        return PerformGetByQuery(query);
    }

    /// <inheritdoc />
    protected override IEnumerable<IFormValidationSetting> PerformGetByQuery(IQuery<IFormValidationSetting> query)
    {
        var sql = GetBaseQuery(false);

        var translator = new SqlTranslator<IFormValidationSetting>(sql, query);

        var translatedSql = translator.Translate();

        var rows = Database.Fetch<FormValidationSettingDto>(translatedSql);

        return rows
            .Select(setting => _settingFactory.Create(setting.Key, setting.FormKey, setting.RuleKey, setting.Type, setting.Definition))
            .ToList();
    }

    /// <inheritdoc />
    protected override void PersistNewItem(IFormValidationSetting item)
    {
        item.ResetIdentity();
        item.AddingEntity();
        var row = _settingFactory.Create(item);
        Database.Insert(row);
    }

    /// <inheritdoc />
    protected override void PersistUpdatedItem(IFormValidationSetting item)
    {
        item.UpdatingEntity();
        var row = _settingFactory.Create(item);
        Database.Update(row);
    }

    /// <inheritdoc />
    protected override Sql<ISqlContext> GetBaseQuery(bool isCount)
    {
        var sql = isCount ? Sql().SelectCount() : Sql().Select<FormValidationSettingDto>();
        return sql.From<FormValidationSettingDto>();
    }

    /// <inheritdoc />
    protected override string GetBaseWhereClause() => $"{FormValidationSettingDto.TableName}.[Key] = @key";

    /// <inheritdoc />
    protected override IEnumerable<string> GetDeleteClauses() => new[]
    {
        $"DELETE FROM {FormValidationSettingDto.TableName} WHERE [Key] = @key",
    };
}