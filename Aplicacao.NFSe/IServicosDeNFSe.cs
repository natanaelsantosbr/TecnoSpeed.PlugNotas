using Aplicacao.NFSe.Modelos;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe
{
    public interface IServicosDeNFSe
    {
        [Get("/nfse/{idNota}")]
        Task<ApiResponse<BuscarNFSe>> BuscarNotaAsync([Header("x-api-key")] string apiKey, string idNota);

        [Post("/nfse")]
        Task<ApiResponse<RetornoNFSe>> CadastrarAsync([Header("x-api-key")] string apiKey, List<CadastrarNFSe> modelo);
    }
}
