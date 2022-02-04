using Aplicacao.NFSe.Empresas.Modelos;
using Aplicacao.NFSe.Empresas.Modelos.Retornos;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.Empresas
{
    public interface IServicosDeEmpresas
    {
        [Post("/empresa")]
        Task<ApiResponse<RetornoCadastroDeEmpresa>> CadastrarAsync([Header("x-api-key")] string apiKey, CadastrarEmpresa modelo);

        [Patch("/empresa/{cnpj}")]
        Task<ApiResponse<string>> AlterarAsync([Header("x-api-key")] string apiKey, string cnpj, AlterarEmpresa modelo);

        [Get("/empresa")]
        Task<string> BuscarTodosAsync([Header("x-api-key")] string apiKey);

        [Get("/empresa/{cnpj}")]
        Task<ApiResponse<BuscarEmpresa>> BuscarPorCNPJAsync([Header("x-api-key")] string apiKey, string cnpj);
    }
}
