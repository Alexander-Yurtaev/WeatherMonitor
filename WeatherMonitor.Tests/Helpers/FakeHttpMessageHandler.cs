using System.Net;
using System.Text;

namespace WeatherMonitor.Tests.Helpers;

public class FakeHttpMessageHandler : HttpMessageHandler
{
    private string _json;

    public FakeHttpMessageHandler(string json)
    {
        _json = json;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken _)
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_json, Encoding.UTF8, "application/json")
        };
        return Task.FromResult(response);
    }
}
