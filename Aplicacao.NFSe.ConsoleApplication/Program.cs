using Aplicacao.NFSe.ConsoleApplication.Testar.CertificadosDigitais;
using Aplicacao.NFSe.ConsoleApplication.Testar.Empresas;
using Aplicacao.NFSe.ConsoleApplication.Testar.NFSe;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication
{
    class Program
    {
        private static string _url = "https://api.sandbox.plugnotas.com.br";
        private static string _key = "2da392a6-79d2-4304-a8b7-959572c7e44d";

        static async Task Main(string[] args)
        {
            var testarCertificadosDigitais = new TestarCertificadosDigitais(_url, _key, "cd");
            await testarCertificadosDigitais.Inicializar();

            var testarEmpresas = new TestarEmpresas(_url, _key, "empresa");
            await testarEmpresas.Inicializar();

            var testarNFSe = new TestarNFSe(_url, _key, "nfse");
            await testarNFSe.Inicializar();
        }
    }
}
