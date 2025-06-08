using ConsultaCep.Domain.Entities;
using System.Threading.Tasks;

namespace ConsultaCep.Application.Ports;

public interface ICepService
{
  Task<CepInfo> ObterCepAsync(string cep);
}
