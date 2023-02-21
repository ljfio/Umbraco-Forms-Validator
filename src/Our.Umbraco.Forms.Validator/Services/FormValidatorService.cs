using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Umbraco.Forms.Core.Models;

namespace Our.Umbraco.Forms.Validator.Services;

public sealed class FormValidatorService : IFormValidatorService
{
    public void Validate(Form form, HttpContext context, ModelStateDictionary modelState)
    {
        
    }
}