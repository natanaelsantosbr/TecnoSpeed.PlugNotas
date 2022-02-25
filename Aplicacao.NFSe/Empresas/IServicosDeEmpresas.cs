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
        Task<ApiResponse<string>> AlterarAsync([Header("x-api-key")] string apiKey, string cnpj, CadastrarEmpresa modelo);

        [Get("/empresa")]
        Task<string> BuscarTodosAsync([Header("x-api-key")] string apiKey);

        [Get("/empresa/{cnpj}")]
        Task<ApiResponse<BuscarEmpresa>> BuscarPorCNPJAsync([Header("x-api-key")] string apiKey, string cnpj);

        [Multipart]
        [Post("/empresa/{cnpj}/logotipo")]
        Task<ApiResponse<RetornoUploadDeLogotipo>> UploadLogotipoAsync([Header("x-api-key")] string apiKey, [AliasAs("arquivo")] StreamPart arquivo, string cnpj);

        [Get("/empresa/{cnpj}/logotipo")]
        Task<ApiResponse<string>> DownloadLogotipoAsync([Header("x-api-key")] string apiKey, string cnpj);

        [Delete("/empresa/{cnpj}/logotipo")]
        Task<ApiResponse<string>> ExcluirLogotipoAsync([Header("x-api-key")] string apiKey, string cnpj);

        [Post("/empresa/{cnpj}/webhook")]
        Task<ApiResponse<RetornoCadastroDeWebhook>> CadastrarWebhookAsync([Header("x-api-key")] string apiKey, string cnpj, CadastrarWebhook modelo);

        [Put("/empresa/{cnpj}/webhook")]
        Task<ApiResponse<RetornoCadastroDeWebhook>> AlterarWebhookAsync([Header("x-api-key")] string apiKey, string cnpj, AlterarWebhook modelo);

        [Delete("/empresa/{cnpj}/webhook")]
        Task<ApiResponse<string>> ExcluirWebhookAsync([Header("x-api-key")] string apiKey, string cnpj);

        [Get("/empresa/{cnpj}/webhook")]
        Task<ApiResponse<string>> BuscarWebhookAsync(string key, string cnpj);
    }
}
