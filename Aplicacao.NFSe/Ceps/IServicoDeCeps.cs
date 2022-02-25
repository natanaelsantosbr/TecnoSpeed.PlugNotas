using Aplicacao.NFSe.Ceps.Modelos;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.Ceps
{
    public interface IServicoDeCeps
    {
        [Get("/cep/{cep}")]
        Task<ApiResponse<BuscarCep>> BuscarCepAsync([Header("x-api-key")] string apiKey, string cep);
    }
}
