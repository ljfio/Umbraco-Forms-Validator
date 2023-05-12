// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Umbraco.Cms.Core.Persistence;
using Umbraco.Cms.Infrastructure.Scoping;

namespace Our.Umbraco.Forms.Validator.Core.Extensions;

public static class RepositoryExtensions
{
    public static IEnumerable<TEntity> Get<TEntity>(this IQueryRepository<TEntity> repository, IScope scope)
    {
        var query = scope.SqlContext.Query<TEntity>();
        return repository.Get(query);
    }
}