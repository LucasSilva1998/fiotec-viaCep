ViaCEP Service API






📝 Descrição

API responsável por consultar endereços a partir de um CEP utilizando o serviço público ViaCEP.
Centraliza o serviço de consulta para ser reutilizado por outras APIs, evitando múltiplas integrações diretas.

🚀 Endpoints
Método	Endpoint	Descrição	Resposta
GET	/api/endereco/{cep}	Consulta endereço pelo CEP	200 OK → Retorna o endereço completo
404 Not Found → CEP não encontrado
500 Internal Server Error → Erro inesperado

Exemplo de requisição:

GET http://localhost:5000/api/endereco/21040361


Exemplo de retorno (200 OK):

{
  "cep": "21040-361",
  "logradouro": "Rua Exemplo",
  "complemento": "",
  "bairro": "Bangu",
  "localidade": "Rio de Janeiro",
  "uf": "RJ",
  "unidade": "",
  "ibge": "3304557",
  "gia": ""
}

📑 Swagger

A documentação da API está disponível via Swagger:

http://localhost:5000/


Exemplo de tela do Swagger:


⚙️ Configuração (appsettings.json)
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ViaCepSettings": {
    "BaseUrl": "https://viacep.com.br/ws/",
    "TimeoutSeconds": 5,
    "RetryCount": 3
  }
}

🏛️ Arquitetura

A API segue Clean Architecture / DDD:

fiotec-viaCep
│
├── API (Presentation)
│   ├── Controllers
│   ├── Middlewares
│   └── Extensions
│
├── Application
│   ├── Interfaces
│   └── Services
│
├── Infra
│   ├── Services
│   └── DTOs
│
└── Tests
    └── Integration

Middlewares

ExceptionHandlingMiddleware: captura exceções globais, como NaoEncontradoException e erros 500, retornando JSON padronizado.

HttpClient

Timeout e Retry configuráveis via appsettings.json

Polly para retry em falhas transientes

CancellationToken suportado

🧪 Testes

Testes de integração criados na camada Infra.Tests

Validam:

CEP válido → retorna endereço completo

CEP inexistente → retorna null (mapeado para 404)

Exemplo:

dotnet test fiotec_viaCep.Infra.Tests

📌 Boas práticas aplicadas

Clean Architecture / DDD

Middleware para tratamento global de erros

HttpClientFactory + Polly

DTOs padronizados

Swagger bem documentado

CancellationToken suportado

⚡ Como usar

Clone o repositório:

git clone https://github.com/LucasSilva1998/fiotec-viaCep.git


Execute a API:

dotnet run --project fiotec_viaCep.API


Teste via Swagger ou Postman:

GET http://localhost:5000/api/endereco/21040361
