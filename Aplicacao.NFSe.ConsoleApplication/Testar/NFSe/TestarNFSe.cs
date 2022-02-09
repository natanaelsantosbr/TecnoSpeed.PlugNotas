using Aplicacao.NFSe.Empresas.Modelos.Interno;
using Aplicacao.NFSe.Modelos;
using Aplicacao.NFSe.Modelos.Interno;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication.Testar.NFSe
{
    public class TestarNFSe : ITestarNFSe
    {
        private string _url;
        private string _key;
        private string _grupo;

        public TestarNFSe(string urlPadrao, string key, string grupo)
        {
            this._url = urlPadrao;
            this._key = key;
            this._grupo = grupo;
        }

        public async Task Inicializar()
        {
            var servicoNFSe = RestService.For<IServicosDeNFSe>(_url);

            var notaId = await EmitirNota(servicoNFSe);

            await BuscarNota(servicoNFSe, notaId);

            await DownloadPDF(servicoNFSe, notaId);

            await DownloadXML(servicoNFSe, notaId);

            var cancellationProtocol = await SolicitarCancelamento(servicoNFSe, notaId);

            await ConsultarCancelamento(servicoNFSe, cancellationProtocol);
        }

        private async Task<string> EmitirNota(IServicosDeNFSe servicoNFSe)
        {
            var idDeIntegracao = Guid.NewGuid().ToString();

            var enderecoPrestador = new Endereco("Maringá", "87020025", TipoLogradouro.Avenida, "Duque de Caxias",
                TipoBairro.Centro, "4115200", "17 andar", Estado.PR, "882", "Centro"); ;

            var telefoneDoPrestador = new Telefone("44", "43214321");

            var prestador = new Prestador("08187168000160", "Tecnospeed TI S/A", "Tecnospeed TI S/A",
                "12345", "9044016688", false, false, false, 0, 0, "exemplo@erphub.com.br", enderecoPrestador,
                telefoneDoPrestador);

            var enderecoDoTomador = new Endereco("Maringa", "87020100", TipoLogradouro.Rua, "Barao do rio branco", TipoBairro.Centro,
                "4115200", "sala 01", Estado.PR, "1001", "Centro");

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

            var novaNota = new CadastrarNFSe(idDeIntegracao, prestador, tomador, servico, impressao, true);

            lista.Add(novaNota);

            var resultado = await servicoNFSe.CadastrarAsync(_key, lista);

            var retorno = resultado.Content.documents.First().id;

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Emitir - {retorno}");

            return retorno;
        }

        private async Task BuscarNota(IServicosDeNFSe servicoNFSe, string notaId)
        {
            var resultado = await servicoNFSe.BuscarNotaAsync(_key, notaId);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Buscar - {resultado.Content.status}");
        }

        private async Task DownloadPDF(IServicosDeNFSe servicoNFSe, string notaId)
        {
            var resultado = await servicoNFSe.DownloadPDF(_key, notaId);

            byte[] ByteArray = await resultado.Content.ReadAsByteArrayAsync();

            System.IO.Directory.CreateDirectory("pdf");

            System.IO.File.WriteAllBytes($"pdf/{notaId}.pdf", ByteArray);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Download PDF - {notaId}");
        }

        private async Task DownloadXML(IServicosDeNFSe servicoNFSe, string notaId)
        {
            var resultado = await servicoNFSe.DownloadXML(_key, notaId);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Download XML - {notaId}");
        }

        private async Task<string> SolicitarCancelamento(IServicosDeNFSe servicoNFSe, string notaId)
        {
            Thread.Sleep(5000);

            var tipoDeCancelamento = new TipoDeCancelamento("C099", "É necessário o body ao cancelar uma NFSe, para incluir o código de cancelamento da cidade.");

            var resultado = await servicoNFSe.SolicitarCancelamentoAsync(_key, notaId, tipoDeCancelamento);

            var protocol = resultado.Content.data.protocol;

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Solicitar Cancelamento - {protocol}");

            return protocol;
        }

        private async Task ConsultarCancelamento(IServicosDeNFSe servicoNFSe, string cancellationProtocol)
        {
            Thread.Sleep(5000);

            var resultado = await servicoNFSe.ConsultarCancelamentoAsync(_key, cancellationProtocol);

            var resposta = resultado.Content.data.response;

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Consultar Cancelamento - {resposta}");

        }
    }
}
