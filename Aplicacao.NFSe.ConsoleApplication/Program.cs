using Aplicacao.NFSe.CertificadosDigitais;
using Aplicacao.NFSe.Empresas;
using Aplicacao.NFSe.Modelos;
using Aplicacao.NFSe.Modelos.Interno;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var servicoNFSe = RestService.For<IServicosDeNFSe>(_url);
            var grupo = "Emitir Nota";

            var notaId =  await EmitirNota(servicoNFSe, grupo);

            await BuscarNota(servicoNFSe, notaId, grupo);

            await DownloadPDF(servicoNFSe, notaId, grupo);
        }       

        private static async Task<string> EmitirNota(IServicosDeNFSe servicoNFSe, string grupo)
        {            
            var enderecoPrestador = new Endereco("Maringá", "87020025", "Avenida", "Duque de Caxias",
                "Centro", "4115200", "17 andar", "PR", "882", "Centro");

            var telefoneDoPrestador = new Telefone("44", "43214321");

            var prestador = new Prestador("08187168000160", "Tecnospeed TI S/A", "Tecnospeed TI S/A",
                "12345", "9044016688", false, false, false, 0,0, "exemplo@erphub.com.br", enderecoPrestador,
                telefoneDoPrestador);

            var enderecoDoTomador = new Endereco("Maringa", "87020100", "Rua", "Barao do rio branco", "Centro",
                "4115200", "sala 01", "PR", "1001", "Centro");

            var tomador = new Tomador("99999999999999", "Empresa de Teste LTDA", "Empresa de Teste",
                "8214100099", "string", "exemplo@erphub.com.br", enderecoDoTomador, telefoneDoPrestador);

            var iss = new Iss(1, false, 3, 2, 7);

            var pis = new Pis(0.65);
            var cofins = new Cofins(3);
            var csll = new Csll(0);
            var retencao = new Retencao(pis, cofins, csll);

            var valor = new Valor(0, 0.1, 45, 0, 0, 0.1);

            var servico = new Servico("0107", "Programação", "Programação de software", "00000",
                "4115200", "4115200", "MARINGA", iss, retencao, valor);

            var impressao = new Impressao(new CamposCustomizados("1", "1|2", "1|2|3"));

            var lista = new List<CadastrarNFSe>();

            var novaNota = new CadastrarNFSe(prestador, tomador, servico, impressao, true);

            lista.Add(novaNota);

            var resultado = await servicoNFSe.CadastrarAsync(_key, lista);

            var retorno = resultado.Content.documents.First().id;

            if (resultado != null)
                Console.WriteLine($"{grupo} - Emitir - {retorno}");

            return retorno;
        }

        private static async Task BuscarNota(IServicosDeNFSe servicoNFSe, string notaId,  string grupo)
        {
            var resultado = await servicoNFSe.BuscarNotaAsync(_key, notaId);

            if (resultado != null)
                Console.WriteLine($"{grupo} - Buscar - {resultado.Content.status}");
        }

        private static async Task DownloadPDF(IServicosDeNFSe servicoNFSe, string notaId, string grupo)
        {
            var resultado = await servicoNFSe.DownloadPDF(_key, notaId);

            byte[] ByteArray = await resultado.Content.ReadAsByteArrayAsync();

            System.IO.Directory.CreateDirectory("pdf");

            System.IO.File.WriteAllBytes($"pdf/{notaId}.pdf", ByteArray);

            if (resultado != null)
                Console.WriteLine($"{grupo} - Download PDF - {notaId}");
        }

        private static async Task TestarEmpresas()
        {
            var servicoEmpresas = RestService.For<IServicosDeEmpresas>(_url);

            var resultado = await servicoEmpresas.BuscarPorCNPJAsync(_key, "08187168000160");

            if(resultado != null)
                Console.WriteLine("Buscar todas as empresas ok");
        }

        private static async Task TestarCertificadosDigitais()
        {
            var servicoCertificadosDigitais = RestService.For<IServicosDeCertificadosDigitais>(_url);

            var resultado = await servicoCertificadosDigitais.BuscarTodosAsync(_key);

            if (resultado != null)
                Console.WriteLine("Buscar todos os certificados ok");
        }
    }
}
