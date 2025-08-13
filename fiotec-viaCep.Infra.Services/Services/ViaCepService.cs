using fiotec_viaCep.Infra.Services.Dto;
using fiotec_viaCep.Infra.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace fiotec_viaCep.Infra.Services.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");
        }

        public async Task<ViaCepResponse?> BuscarEnderecoPorCepAsync(string cep, CancellationToken ct = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cep))
                    return null;

                cep = new string(cep.Where(char.IsDigit).ToArray());

                if (cep.Length != 8)
                    return null;

                var response = await _httpClient.GetAsync($"{cep}/json/", ct);

                if (!response.IsSuccessStatusCode)
                    return null;

                var endereco = await response.Content.ReadFromJsonAsync<ViaCepResponse>(cancellationToken: ct);

                if (endereco == null || string.IsNullOrWhiteSpace(endereco.Cep))
                    return null;

                return endereco;
            }
            catch (HttpRequestException)
            {
                return null;
            }
            catch (JsonException)
            {
                return null;
            }
        }
    }
}
