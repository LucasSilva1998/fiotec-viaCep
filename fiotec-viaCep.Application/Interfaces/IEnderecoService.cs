using fiotec_viaCep.Infra.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiotec_viaCep.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<ViaCepResponse?> ObterEnderecoPorCepAsync(string cep, CancellationToken ct = default);
    }
}