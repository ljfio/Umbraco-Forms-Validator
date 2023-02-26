// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Core.Tests.Rules;

public class RuleCollectionTests
{
    private readonly FormValidationRuleCollection _collection;

    private static readonly Guid _expectedId = new("8DFB2E11-E525-4354-BEF0-67DAFE1E4559");

    public RuleCollectionTests()
    {
        var items = new FormValidationRule[]
        {
            new ExampleRule(),
        };
        
        _collection = new FormValidationRuleCollection(() => items);
    }

    [Fact]
    public void ContainsOneItem()
    {
        Assert.Equal(1, _collection.Count);
    }

    [Fact]
    public void ThrowsKeyNotFound()
    {
        Assert.Throws<KeyNotFoundException>(() => _collection[Guid.Empty]);
    }

    [Fact]
    public void ItemHasExpectedId()
    {
        var item = _collection[_expectedId];
        
        Assert.Equal(_expectedId, item.Id);
    }
    
    private class ExampleRule : FormValidationRule
    {
        public ExampleRule()
        {
            Id = _expectedId;
        }

        public override bool Validate(FormValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
