using fiotec_viaCep.Application.Interfaces;
using fiotec_viaCep.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiotec_viaCep.Application.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)

        {
            services.AddScoped<IEnderecoService, EnderecoService>();

            return services;
        }
    }
}