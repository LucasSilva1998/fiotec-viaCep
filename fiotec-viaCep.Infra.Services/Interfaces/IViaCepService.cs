using fiotec_viaCep.Infra.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiotec_viaCep.Infra.Services.Interfaces
{
    public interface IViaCepService
    {
        Task<ViaCepResponse?> BuscarEnderecoPorCepAsync(string cep, CancellationToken ct = default);
    }
}