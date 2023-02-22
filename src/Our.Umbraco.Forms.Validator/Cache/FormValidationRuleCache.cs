using System.Collections.ObjectModel;
using Our.Umbraco.Forms.Validator.Core.Cache;
using Our.Umbraco.Forms.Validator.Core.Rules;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Cache;

public class FormValidationRuleCache : IFormValidationRuleCache
{
    private IDictionary<Guid, IList<IFormValidationRule>> _rulesCache;

    public FormValidationRuleCache()
    {
        _rulesCache = new Dictionary<Guid, IList<IFormValidationRule>>();
    }

    public void AddRule(Form form, IFormValidationRule rule)
    {
        if (!_rulesCache.ContainsKey(form.Id))
        {
            _rulesCache.Add(form.Id, new List<IFormValidationRule>());
        }

        var rules = _rulesCache[form.Id];
        
        rules.Add(rule);
    }

    public IEnumerable<IFormValidationRule> GetRulesFor(Form form)
    {
        if (_rulesCache.ContainsKey(form.Id))
        {
            return new ReadOnlyCollection<IFormValidationRule>(_rulesCache[form.Id]);
        }

        return Enumerable.Empty<IFormValidationRule>();
    }
}