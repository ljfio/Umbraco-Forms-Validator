using Microsoft.AspNetCore.Http;

namespace Our.Umbraco.Forms.Validator.Core.Rules;

public interface IFormValidationRule
{
    bool Validate(FormValidationContext context);
}