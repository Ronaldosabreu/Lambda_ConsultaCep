using ConsultaCep.Application.Ports;
using ConsultaCep.Domain.Entities;

namespace ConsultaCep.Infrastructure.Services;

public class ViaCepService : ICepService
{
  private readonly IViaCepApi _api;

  public ViaCepService(IViaCepApi api)
  {
    _api = api;
  }

  public async Task<CepInfo> ObterCepAsync(string cep)
  {
    return await _api.GetCepAsync(cep);
  }
}

public interface IViaCepApi
{
  [Refit.Get("/{cep}/json")]
  Task<CepInfo> GetCepAsync(string cep);
}
