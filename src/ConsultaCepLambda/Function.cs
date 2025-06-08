using Amazon.Lambda.Core;
using ConsultaCep.Application.Ports;
using ConsultaCep.Domain.Entities;
using ConsultaCep.Lambda;
using Microsoft.Extensions.DependencyInjection;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ConsultaCepLambda;

public class Function
{
  private readonly ICepService _cepService;

  public Function() : this(Program.Configure().GetService<ICepService>()) { }

  public Function(ICepService cepService)
  {
    _cepService = cepService;
  }

  /// <summary>
  /// A simple function that takes a string and does a ToUpper
  /// </summary>
  /// <param name="input">The event for the Lambda function handler to process.</param>
  /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
  /// <returns></returns>
  public async Task<CepInfo> FunctionHandler(string cep, ILambdaContext context)
  {
    return await _cepService.ObterCepAsync(cep);
  }
}
