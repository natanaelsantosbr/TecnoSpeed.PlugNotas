using Aplicacao.NFSe.Modelos;
using Aplicacao.NFSe.Modelos.Interno;
using Aplicacao.NFSe.Modelos.Retornos.Cancelar;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe
{
    public interface IServicosDeNFSe
    {
        [Post("/nfse")]
        Task<ApiResponse<RetornoNFSe>> CadastrarAsync([Header("x-api-key")] string apiKey, List<CadastrarNFSe> modelo);

        [Get("/nfse/{idNota}")]
        Task<ApiResponse<BuscarNFSe>> BuscarNotaAsync([Header("x-api-key")] string apiKey, string idNota);

        [Post("/nfse/cancelar/{idNota}")]
        Task<ApiResponse<RetornoDeSolicitacaoDeCancelamento>> SolicitarCancelamentoAsync([Header("x-api-key")] string apiKey, string idNota, TipoDeCancelamento tipoDeCancelamento);

        [Get("/nfse/cancelar/status/{cancellationProtocol}")]
        Task<ApiResponse<RetornoDeConsultarCancelamento>> ConsultarCancelamentoAsync([Header("x-api-key")] string apiKey, string cancellationProtocol);

        [Get("/nfse/pdf/{idNota}")]
        Task<ApiResponse<HttpContent>> DownloadPDF([Header("x-api-key")] string apiKey, string idNota);

        [Get("/nfse/xml/{idNota}")]
        Task<ApiResponse<string>> DownloadXML([Header("x-api-key")] string apiKey, string idNota);
    }
}
