// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Our.Umbraco.Forms.Validator.Core.Rules;

namespace Our.Umbraco.Forms.Validator.Core.Tests.Rules;

public class RuleCollectionTests
{
    private readonly FormValidationRuleCollection _collection;

    private static readonly Guid ExpectedId = new("8DFB2E11-E525-4354-BEF0-67DAFE1E4559");

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
        var item = _collection[ExpectedId];
        
        Assert.Equal(ExpectedId, item.Id);
    }
    
    private class ExampleRule : FormValidationRule
    {
        public ExampleRule()
        {
            Id = ExpectedId;
        }

        public override void Validate(FormValidationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
