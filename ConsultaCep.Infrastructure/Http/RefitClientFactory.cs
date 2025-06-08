using Polly;
using Refit;
using Microsoft.Extensions.Http;

namespace ConsultaCep.Infrastructure.Http;

public static class RefitClientFactory
{
  public static T CreateClient<T>(string baseUrl, IAsyncPolicy<HttpResponseMessage> policy)
  {
    var handler = new PolicyHttpMessageHandler(policy)
    {
      InnerHandler = new HttpClientHandler()
    };

    var client = new HttpClient(handler)
    {
      BaseAddress = new Uri(baseUrl)
    };

    var refitSettings = new RefitSettings
    {
      ContentSerializer = new NewtonsoftJsonContentSerializer()
    };

    return RestService.For<T>(client, refitSettings);
  }
}
