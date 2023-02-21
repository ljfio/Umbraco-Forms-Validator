using Microsoft.AspNetCore.Http;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Core;

public sealed class FormValueProvider
{
    private readonly Form _form;
    
    private readonly HttpContext _context;

    public FormValueProvider(Form form, HttpContext context)
    {
        _form = form;
        _context = context;
    }

    public FormFieldValue? GetFormValue(string alias)
    {
        var field = GetField(alias);

        if (field is null) 
            return null;

        var value = GetValue(field.Id.ToString());

        return new FormFieldValue(_form, field, value);
    }

    private Field? GetField(string alias)
    {
        return _form.AllFields.SingleOrDefault(field => field.Alias == alias);
    }

    private string? GetValue(string id)
    {
        var request = _context.Request;
        
        return request.HasFormContentType && request.Form.ContainsKey(id)
            ? request.Form[id].ToString()
            : null;
    }
}