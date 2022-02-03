using Aplicacao.NFSe.Empresas;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication.Testar.Empresas
{
    public class TestarEmpresas : ITestarEmpresas
    {
        private string _url;
        private string _key;

        public TestarEmpresas(string urlPadrao, string key)
        {
            this._url = urlPadrao;
            this._key = key;
        }

        public async Task Inicializar()
        {
            var servicoEmpresas = RestService.For<IServicosDeEmpresas>(_url);

            var resultado = await servicoEmpresas.BuscarPorCNPJAsync(_key, "08187168000160");

            if (resultado != null)
                Console.WriteLine("Buscar todas as empresas ok");
        }
    }
}
