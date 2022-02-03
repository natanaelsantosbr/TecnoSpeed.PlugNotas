using Aplicacao.NFSe.Empresas.Modelos;
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
        Task CadastrarAsync([Header("x-api-key")] string apiKey, CadastrarEmpresa modelo);

        [Post("/empresa")]
        Task AlterarAsync([Header("x-api-key")] string apiKey, CadastrarEmpresa modelo);

        [Get("/empresa")]
        Task<string> BuscarTodosAsync([Header("x-api-key")] string apiKey);

        [Get("/empresa/{cnpj}")]
        Task<ApiResponse<BuscarEmpresa>> BuscarPorCNPJAsync([Header("x-api-key")] string apiKey, string cnpj);
    }
}
