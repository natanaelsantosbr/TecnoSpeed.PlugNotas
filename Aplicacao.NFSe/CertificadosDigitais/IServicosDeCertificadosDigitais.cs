using Aplicacao.NFSe.CertificadosDigitais.Modelos;
using Aplicacao.NFSe.CertificadosDigitais.Retornos;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.CertificadosDigitais
{
    public interface IServicosDeCertificadosDigitais
    {
        [Multipart]
        [Post("/certificado")]
        Task<ApiResponse<RetornoDeCadastroDeCD>> CadastrarAsync([Header("x-api-key")] string apiKey, [AliasAs("arquivo")] StreamPart arquivo, string senha);

        [Get("/certificado")]
        Task<ApiResponse<List<BuscarCD>>> BuscarTodosAsync([Header("x-api-key")] string apiKey);

        [Get("/certificado/{idCertificado}")]
        Task<ApiResponse<BuscarCD>> BuscarPorIdAsync([Header("x-api-key")] string apiKey, string idCertificado);

        [Multipart]
        [Put("/certificado/{idCertificado}")]
        Task<ApiResponse<RetornoDeCadastroDeCD>> AlterarAsync([Header("x-api-key")] string apiKey, string idCertificado, [AliasAs("arquivo")] StreamPart arquivo, string senha);
    }
}
