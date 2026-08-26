using System.Net;
using System.Text;

namespace WeatherMonitor.Tests.Helpers;

public class FailHttpMessageHandler : HttpMessageHandler
{
    private HttpStatusCode _errorCode;
    private string _errorContent;

    public FailHttpMessageHandler(HttpStatusCode errorCode, string errorContent)
    {
        _errorCode = errorCode;
        _errorContent = errorContent;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(_errorCode);
        response.Content = new StringContent(_errorContent, Encoding.UTF8, "application/json");
        return Task.FromResult(response);
    }
}