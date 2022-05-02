using Aplicacao.NFSe.ConsoleApplication.Testar.CertificadosDigitais;
using Aplicacao.NFSe.ConsoleApplication.Testar.Empresas;
using Aplicacao.NFSe.ConsoleApplication.Testar.NFSe;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication
{
    class Program
    {
        private static string _url = "https://api.plugnotas.com.br";
        private static string _key = "2230289f-9269-458a-aded-927056a5f3c5";

        static async Task Main(string[] args)
        {
            //var testarCertificadosDigitais = new TestarCertificadosDigitais(_url, _key, "cd");
            //var idCertificado =  await testarCertificadosDigitais.Inicializar();

            var idCertificado = "6224feabfb332268d16416c0";

            //QuebraLinha();

            var testarEmpresas = new TestarEmpresas(_url, _key, "empresa");
            await testarEmpresas.Inicializar(idCertificado);
            //QuebraLinha();

            //var testarNFSe = new TestarNFSe(_url, _key, "nfse");
            //await testarNFSe.Inicializar();
        }

        private static void QuebraLinha()
        {
            System.Console.WriteLine("");
        }
    }
}
