using Aplicacao.NFSe.CertificadosDigitais;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication.Testar.CertificadosDigitais
{
    public class TestarCertificadosDigitais : ITestarCertificadosDigitais
    {
        private string _url;
        private string _key;

        public TestarCertificadosDigitais(string urlPadrao, string key)
        {
            this._url = urlPadrao;
            this._key = key;
        }

        public async Task Inicializar()
        {
            var servicoCertificadosDigitais = RestService.For<IServicosDeCertificadosDigitais>(_url);
            await BuscarTodosOsCDs(servicoCertificadosDigitais);
        }

        private async Task BuscarTodosOsCDs(IServicosDeCertificadosDigitais servicoCertificadosDigitais)
        {
            var resultado = await servicoCertificadosDigitais.BuscarTodosAsync(_key);

            if (resultado != null)
                Console.WriteLine("Buscar todos os certificados ok");
        }
    }
}
