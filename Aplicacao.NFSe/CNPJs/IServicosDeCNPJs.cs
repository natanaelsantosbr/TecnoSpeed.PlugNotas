using Aplicacao.NFSe.CNPJs.Modelos;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.CNPJs
{
    public interface IServicosDeCNPJs
    {
        [Get("/cnpj/{cnpj}")]
        Task<ApiResponse<BuscarEmpresa>> ConsultarCnpjAsync([Header("x-api-key")] string apiKey, string cnpj);
    }
}
