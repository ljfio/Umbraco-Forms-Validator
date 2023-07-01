// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.Extensions.Logging;
using Our.Umbraco.Forms.Validator.Core.Services;
using Our.Umbraco.Forms.Validator.Core.Settings;
using Our.Umbraco.Forms.Validator.Persistence.Repositories;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;

namespace Our.Umbraco.Forms.Validator.Services;

public sealed class FormValidationSettingService : RepositoryService, IFormValidationSettingService
{
    private readonly IFormValidationSettingRepository _repository;

    public FormValidationSettingService(
        ICoreScopeProvider provider,
        ILoggerFactory loggerFactory,
        IEventMessagesFactory eventMessagesFactory,
        IFormValidationSettingRepository repository) :
        base(
            provider,
            loggerFactory,
            eventMessagesFactory)
    {
        _repository = repository;
    }

    #region Get

    public IEnumerable<IFormValidationSetting> Get()
    {
        using var scope = ScopeProvider.CreateCoreScope(autoComplete: true);

        var query = Query<IFormValidationSetting>();

        return _repository.Get(query);
    }

    public IFormValidationSetting? Get(Guid key)
    {
        using var scope = ScopeProvider.CreateCoreScope(autoComplete: true);

        return _repository.Get(key);
    }

    public IEnumerable<IFormValidationSetting> GetByForm(Guid key)
    {
        using var scope = ScopeProvider.CreateCoreScope(autoComplete: true);

        var query = Query<IFormValidationSetting>()
            .Where(setting => setting.FormKey == key);

        return _repository.Get(query);
    }

    #endregion

    #region Save

    public Attempt<OperationResult?> Save(IFormValidationSetting setting)
    {
        using var scope = ScopeProvider.CreateCoreScope();

        var eventMessages = EventMessagesFactory.Get();

        _repository.Save(setting);

        scope.Complete();

        return OperationResult.Attempt.Succeed(eventMessages);
    }

    #endregion

    #region Delete

    public Attempt<OperationResult?> Delete(IFormValidationSetting setting)
    {
        using var scope = ScopeProvider.CreateCoreScope();

        var eventMessages = EventMessagesFactory.Get();

        _repository.Delete(setting);

        scope.Complete();

        return OperationResult.Attempt.Succeed(eventMessages);
    }

    #endregion
}