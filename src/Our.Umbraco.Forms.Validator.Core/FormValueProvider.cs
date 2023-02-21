using Microsoft.AspNetCore.Http;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core;

public sealed class FormValueProvider
{
    private readonly Form _form;
    
    private readonly HttpContext _context;

    public FormValueProvider(Form form, HttpContext context)
    {
        _form = form;
        _context = context;
    }

    public FormValue? GetFormValue(Guid id)
    {
        var field = GetField(id);

        if (field is null)
            return null;

        var value = GetValue(field.Id);

        return new FormValue(field, value);
    }

    public FormValue? GetFormValue(string alias)
    {
        var field = GetField(alias);

        if (field is null) 
            return null;

        var value = GetValue(field.Id);

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

    private string? GetValue(Guid id)
    {
        string key = id.ToString();
        
        var request = _context.Request;
        
        return request.HasFormContentType && request.Form.ContainsKey(key)
            ? request.Form[key].ToString()
            : null;
    }
}