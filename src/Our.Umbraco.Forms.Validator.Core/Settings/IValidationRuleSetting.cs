namespace Our.Umbraco.Forms.Validator.Core.Settings;

public interface IValidationRuleSetting
{
    Guid FieldId { get; }
    string? Message { get; set; }
}