using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core.Settings;

public abstract class ValidationRuleSettingBase : IValidationRuleSetting
{
    public Guid FieldId { get; set; }
    
    public string? Message { get; set; }
}