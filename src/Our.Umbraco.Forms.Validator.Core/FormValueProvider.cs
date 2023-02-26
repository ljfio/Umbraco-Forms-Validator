// Copyright 2023 Luke Fisher
// SPDX-License-Identifier: Apache-2.0

using Microsoft.AspNetCore.Http;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Core;

public sealed class FormValueProvider
{
    private readonly Form _form;
    private readonly HttpRequest _request;

    public FormValueProvider(Form form, HttpRequest request)
    {
        _form = form;
        _request = request;
    }

    public FormValue? GetFormValue(Guid id)
    {
        var field = GetField(id);

        if (field is null)
            return null;

        return GetFormValue(field);
    }

    public FormValue? GetFormValue(string alias)
    {
        var field = GetField(alias);

        if (field is null)
            return null;

        return GetFormValue(field);
    }

    public FormValue GetFormValue(Field field)
    {
        var value = GetValue(field.Id);

        return new FormValue(field, value);
    }

    public Field? GetField(Guid id)
    {
        return _form.AllFields.SingleOrDefault(field => field.Id == id);
    }

    public Field? GetField(string alias)
    {
        return _form.AllFields.SingleOrDefault(field => field.Alias == alias);
    }

    private string? GetValue(Guid id)
    {
        string key = id.ToString();

        return _request.HasFormContentType && _request.Form.ContainsKey(key)
            ? _request.Form[key].ToString()
            : null;
    }
}