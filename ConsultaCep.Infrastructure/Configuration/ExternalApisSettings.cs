namespace ConsultaCep.Infrastructure.Configuration;

public class ApiSettings
{
  public string BaseUrl { get; set; }
  public int RetryCount { get; set; } = 3;
  public int TimeoutSeconds { get; set; } = 10;
}

public class ExternalApisSettings
{
  public ApiSettings ViaCep { get; set; }
}
