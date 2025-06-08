using Polly;
using Polly.Extensions.Http;

namespace ConsultaCep.Infrastructure.Policies;

public static class HttpPolicies
{
  public static IAsyncPolicy<HttpResponseMessage> CreateRetryPolicy(int retryCount)
  {
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .WaitAndRetryAsync(retryCount, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)));
  }

  public static IAsyncPolicy<HttpResponseMessage> CreateTimeoutPolicy(int seconds)
  {
    return Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(seconds));
  }

  public static IAsyncPolicy<HttpResponseMessage> CreateResiliencePolicy(int retryCount, int timeoutSeconds)
  {
    var retry = CreateRetryPolicy(retryCount);
    var timeout = CreateTimeoutPolicy(timeoutSeconds);
    return Policy.WrapAsync(retry, timeout);
  }
}
