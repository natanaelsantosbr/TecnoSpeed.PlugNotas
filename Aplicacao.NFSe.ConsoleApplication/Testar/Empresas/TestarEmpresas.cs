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
        private string _grupo;

        public TestarEmpresas(string urlPadrao, string key, string grupo)
        {
            this._url = urlPadrao;
            this._key = key;
            this._grupo = grupo;
        }

        public async Task Inicializar()
        {
            var servicoEmpresas = RestService.For<IServicosDeEmpresas>(_url);

            await BuscarTodosOsCDs(servicoEmpresas);
        }

        private async Task BuscarTodosOsCDs(IServicosDeEmpresas servicoEmpresas)
        {
            var resultado = await servicoEmpresas.BuscarPorCNPJAsync(_key, "08187168000160");

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Buscar por CNPJ");
        }
    }
}
