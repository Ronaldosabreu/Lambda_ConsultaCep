using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConsultaCep.Infrastructure;

namespace ConsultaCep.Lambda;

public static class Program
{
  public static ServiceProvider Configure()
  {
    var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

    var services = new ServiceCollection();

    services.ConfigureInfrastructure(config);

    return services.BuildServiceProvider();
  }
}
