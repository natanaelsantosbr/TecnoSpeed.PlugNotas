using Aplicacao.NFSe.CertificadosDigitais.Modelos;
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
        Task<ApiResponse<BuscarCD>> CadastrarAsync([Header("x-api-key")] string apiKey, CadastrarCD modelo);

        [Get("/certificado")]
        Task<ApiResponse<List<BuscarCD>>> BuscarTodosAsync([Header("x-api-key")] string apiKey);

        [Get("/certificado/{idCertificado}")]
        Task<ApiResponse<BuscarCD>> BuscarPorIdAsync([Header("x-api-key")] string apiKey, string idCertificado);

        [Multipart]
        [Put("/certificado")]
        Task AlterarAsync([Header("x-api-key")] string apiKey, AlterarCD modelo);
    }
}
