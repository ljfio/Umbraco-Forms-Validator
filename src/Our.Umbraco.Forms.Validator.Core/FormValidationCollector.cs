using Our.Umbraco.Forms.Core;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core;

public sealed class FormValidationCollector
{
    private readonly List<FormValidationError> _errors = new();

    public IEnumerable<FormValidationError> Errors => _errors.AsReadOnly();

    public void AddValidationError(FormFieldValue value, string message)
    {
        AddValidationError(value.Field, message);
    }
    
    public void AddValidationError(Field field, string message)
    {
        _errors.Add(new FormValidationError(field, message));
    }
}