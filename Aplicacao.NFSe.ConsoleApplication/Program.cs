using Aplicacao.NFSe.CertificadosDigitais;
using Aplicacao.NFSe.Empresas;
using Refit;
using System;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication
{
    class Program
    {
        private static string _url = "https://api.sandbox.plugnotas.com.br";
        private static string _key = "2da392a6-79d2-4304-a8b7-959572c7e44d";

        static async Task Main(string[] args)
        {
            await TestarCertificadosDigitais();

            await TestarEmpresas();

            await TestarNFSe();
        }

        private static async Task TestarNFSe()
        {
            var hubEmpresas = RestService.For<IServicosDeNFSe>(_url);

            var resultado = await hubEmpresas.BuscarNotaAsync(_key, "5ea2194afffc86aca90aedaa");

            if (resultado != null)
                Console.WriteLine("Buscar nfse ok");
        }

        private static async Task TestarEmpresas()
        {
            var hubEmpresas = RestService.For<IServicosDeEmpresas>(_url);

            var resultado = await hubEmpresas.BuscarPorCNPJAsync(_key, "08187168000160");

            if(resultado != null)
                Console.WriteLine("Buscar todas as empresas ok");
        }

        private static async Task TestarCertificadosDigitais()
        {
            var hubCertificado = RestService.For<IServicosDeCertificadosDigitais>(_url);

            var resultado = await hubCertificado.BuscarTodosAsync(_key);

            if (resultado != null)
                Console.WriteLine("Buscar todos os certificados ok");
        }
    }
}
