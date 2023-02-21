using Microsoft.AspNetCore.Http;

namespace Our.Umbraco.Forms.Validator.Core;

public sealed class FormValidationContext
{
    public FormValidationContext(HttpRequest request, FormValidationCollector collector, FormValueProvider provider)
    {
        Request = request;
        Collector = collector;
        Provider = provider;
    }

    public HttpRequest Request { get; }

    public FormValidationCollector Collector { get; }

    public FormValueProvider Provider { get; }
}