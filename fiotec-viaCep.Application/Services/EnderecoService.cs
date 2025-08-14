using fiotec_viaCep.Application.Exceptions;
using fiotec_viaCep.Application.Interfaces;
using fiotec_viaCep.Infra.Services.Dto;
using fiotec_viaCep.Infra.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiotec_viaCep.Application.Services
{
    public class EnderecoService(IViaCepService viaCepService) : IEnderecoService
    {
        public async Task<ViaCepResponse> ObterEnderecoPorCepAsync(string cep, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(cep))
                throw new ParametroInvalidoException("O CEP não pode ser vazio.");

            var endereco = await viaCepService.BuscarEnderecoPorCepAsync(cep, ct);

            if (endereco == null)
                throw new NaoEncontradoException($"CEP {cep} não encontrado");

            return endereco;
        }
    }
}