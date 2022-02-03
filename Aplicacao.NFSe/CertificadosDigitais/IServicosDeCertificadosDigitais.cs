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
        /// <summary>
        /// Cadastre um certificado digital e vincule a sua Empresa, para que possa iniciar a emissão de notas. 
        /// Quando houver a necessidade do compartilhamento do certificado digital (matriz/filial), não é necessário
        /// subir várias vezes o mesmo certificado, um mesmo ID pode ser vinculado a diversas empresas.
        /// </summary>
        [Multipart]
        [Post("/certificado")]
        Task<ApiResponse<BuscarCD>> CadastrarAsync([Header("x-api-key")] string apiKey, CadastrarCD modelo);

        /// <summary>
        /// Lista todos os certificados vinculados a sua organização.
        /// </summary>
        [Get("/certificado")]
        Task<ApiResponse<List<BuscarCD>>> BuscarTodosAsync([Header("x-api-key")] string apiKey);

        /// <summary>
        /// Utilize para buscar os dados de um certificado específico já cadastrado
        /// </summary>
        [Get("/certificado/{idCertificado}")]
        Task<ApiResponse<BuscarCD>> BuscarPorIdAsync([Header("x-api-key")] string apiKey, string idCertificado);

        /// <summary>
        /// Utilize para atualizar um certificado digital que esteja vinculado a múltiplas empresas. Desta forma, um certificado digital compartilhado (matriz/filial) que esteja vencido, pode ser substituído 
        /// sem a necessidade da atualização de cada empresa individualmente.
        /// </summary>
        [Multipart]
        [Put("/certificado")]
        Task AlterarAsync([Header("x-api-key")] string apiKey, AlterarCD modelo);
    }
}
