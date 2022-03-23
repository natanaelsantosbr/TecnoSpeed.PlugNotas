using Aplicacao.NFSe.Webhooks.Modelos;
using Aplicacao.NFSe.Webhooks.Modelos.Retornos;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.Webhooks
{
    public interface IServicosDeWebhooks
    {
        [Get("/webhook")]
        Task<ApiResponse<RetornoConsultarWebhook>> ConsultarSync([Header("x-api-key")] string apiKey);

        [Put("/webhook")]
        Task<ApiResponse<RetornoAlterarDeWebhook>> AlterarSync([Header("x-api-key")] string apiKey, AlterarWebhook modelo);

        [Post("/webhook")]
        Task<ApiResponse<RetornoCadastroDeWebhook>> CadastrarAsync([Header("x-api-key")] string apiKey, CadastrarWebhook modelo);

        [Delete("/webhook")]
        Task<ApiResponse<RetornoExcluirDeWebhook>> ExcluirSync([Header("x-api-key")] string apiKey);

        [Post("/webhook/verify")]
        Task<ApiResponse<RetornoTestarDeWebhook>> TestarSync([Header("x-api-key")] string apiKey);
    }
}
