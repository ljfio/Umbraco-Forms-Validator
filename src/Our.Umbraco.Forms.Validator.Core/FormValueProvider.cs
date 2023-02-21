using Microsoft.AspNetCore.Http;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core;

public sealed class FormValueProvider
{
    private readonly Form _form;

    public FormValueProvider(Form form)
    {
        _form = form;
    }

    public FormValue? GetFormValue(HttpRequest request, Guid id)
    {
        var field = GetField(id);

        if (field is null)
            return null;

        var value = GetValue(request, field.Id);

        return new FormValue(field, value);
    }

    public FormValue? GetFormValue(HttpRequest request, string alias)
    {
        var field = GetField(alias);

        if (field is null) 
            return null;

        var value = GetValue(request, field.Id);

        return new FormValue(field, value);
    }

    private Field? GetField(Guid id)
    {
        return _form.AllFields.SingleOrDefault(field => field.Id == id);
    }

    private Field? GetField(string alias)
    {
        return _form.AllFields.SingleOrDefault(field => field.Alias == alias);
    }

    private string? GetValue(HttpRequest request, Guid id)
    {
        string key = id.ToString();
        
        return request.HasFormContentType && request.Form.ContainsKey(key)
            ? request.Form[key].ToString()
            : null;
    }
}