using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConsultaCep.Application.Ports;
using ConsultaCep.Infrastructure.Services;
using ConsultaCep.Infrastructure.Http;
using ConsultaCep.Infrastructure.Policies;
using ConsultaCep.Infrastructure.Configuration;
using System.ComponentModel.Design;

namespace ConsultaCep.Infrastructure;

public static class RegisterServices
{
  public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration config)
  {
    var apiSettings = new ExternalApisSettings();
    config.GetSection("ExternalApis").Bind(apiSettings);

    var resiliencePolicy = HttpPolicies.CreateResiliencePolicy(
        apiSettings.ViaCep.RetryCount,
        apiSettings.ViaCep.TimeoutSeconds
    );

    var client = RefitClientFactory.CreateClient<IViaCepApi>(
        apiSettings.ViaCep.BaseUrl,
        resiliencePolicy
    );

    services.AddSingleton<IViaCepApi>(client);
    services.AddSingleton<ICepService, ViaCepService>();
  }
}
