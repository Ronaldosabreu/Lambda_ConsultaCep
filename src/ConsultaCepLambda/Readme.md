.
├── src/
│   ├── Application/
│   ├── Domain/
│   ├── Infrastructure/
│   ├── LambdaEntryPoint/
│   └── Presentation/         # Onde fica o handler da Lambda
├── tests/
├── appsettings.json
├── README.md


# AWS Lambda (.NET) - Consulta CEP com Clean Architecture, Refit e Polly

Este projeto demonstra como implementar uma função AWS Lambda em **.NET 8+**, aplicando princípios de **Clean Architecture**, utilizando **Refit** para integração HTTP com a API do ViaCEP, e **Polly** para tratamento resiliente de falhas.

## 🧱 Arquitetura Utilizada

- ✅ Clean Architecture (camadas: Domain, Application, Infrastructure, Presentation)
- ✅ AWS Lambda (.NET 8)
- ✅ Injeção de Dependência
- ✅ Chamadas HTTP com **Refit**
- ✅ Resiliência com **Polly**
- ✅ Configuração via `appsettings.json`
- ✅ Testes locais com `Amazon.Lambda.TestTool`

---

## 🔧 Requisitos

- .NET 8 SDK ou superior
- AWS CLI configurado (`aws configure`)
- [Amazon.Lambda.Tools](https://github.com/aws/aws-extensions-for-dotnet-cli)
- `Amazon.Lambda.TestTool` (para testes locais)

---

## 📦 Instalação e Execução Local

### 1. Clonar o projeto

```bash
git clone https://github.com/seu-usuario/lambda-cep-clean.git
cd lambda-cep-clean
