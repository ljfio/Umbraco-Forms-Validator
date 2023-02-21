using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Core;

public sealed class FormFieldValue
{
    public FormFieldValue(Form form, Field field, string? value)
    {
        Form = form;
        Field = field;
        Value = value;
    }

    public Form Form { get; }

    public Field Field { get; }

    public string? Value { get; }
}