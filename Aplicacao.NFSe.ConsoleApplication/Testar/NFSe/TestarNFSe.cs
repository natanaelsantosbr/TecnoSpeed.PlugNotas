using Aplicacao.NFSe.Ceps;
using Aplicacao.NFSe.CNPJs;
using Aplicacao.NFSe.Empresas.Modelos.Interno;
using Aplicacao.NFSe.Modelos;
using Aplicacao.NFSe.Modelos.Interno;
using Aplicacao.NFSe.Modelos.Tomadores;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication.Testar.NFSe
{
    public class TestarNFSe : ITestarNFSe
    {
        private string _url;
        private string _key;
        private string _grupo;
        private string _idDeIntegracao;

        public TestarNFSe(string urlPadrao, string key, string grupo)
        {
            this._url = urlPadrao;
            this._key = key;
            this._grupo = grupo;
        }

        public async Task Inicializar()
        {
            var servico = RestService.For<IServicosDeNFSe>(_url);
            var servicoDeBuscaEmpresa = RestService.For<IServicosDeCNPJs>(_url);
            var servicoDeCeps = RestService.For<IServicoDeCeps>(_url);

            var cnpj = "28506113000182";

            //await BuscarTomador(servico, servicoDeBuscaEmpresa, servicoDeCeps, cnpj);

            var notaId = await EmitirNotaV2(servico, servicoDeCeps);

            //var notaId = "6234bd69dd6d66577bb9dc47";

            //var listaDeIds = new string[] { "62276fa1c8c19b2df79342b2" };

            var tomador = "31089572000112";

            var idDeIntegracao = this._idDeIntegracao; // "38c65904-a370-4f48-8b9e-61e8374a0132";

            //await BuscarTomador(servico, servicoDeBuscaEmpresa, servicoDeCeps, tomador);

            await BuscaResumoDaNota(servico, idDeIntegracao, cnpj);

            await BuscarNota(servico, notaId);

            await DownloadPDF(servico, notaId);

            await DownloadXML(servico, notaId);

            //foreach (var notaId in listaDeIds)
            //{
            //    var cancellationProtocol = await SolicitarCancelamento(servico, notaId);
            //    await ConsultarCancelamento(servico, cancellationProtocol);
            //}            
        }

        private async Task BuscarTomador(IServicosDeNFSe servico,
            IServicosDeCNPJs servicosDeCNPJs,
            IServicoDeCeps servicoDeCeps, string cnpj)
        {
            var tomador = await servico.BuscarTomadorAsync(_key, cnpj);

            if (tomador.Content != null)
            {
                if (tomador != null)
                    Console.WriteLine($"{_grupo} - Buscar Tomador - {tomador.Content?.cpfCnpj}");
            }
            else
            {
                await CadastrarTomador(servico, servicosDeCNPJs, servicoDeCeps, cnpj);
            }
        }

        private async Task CadastrarTomador(IServicosDeNFSe servico, IServicosDeCNPJs servicoDeBuscaEmpresa, IServicoDeCeps servicoDeCeps, string cnpj)
        {
            var retorno = await servicoDeBuscaEmpresa.ConsultarCnpjAsync(_key, cnpj);
            var empresa = retorno.Content;

            string cep = empresa.endereco.cep;

            var retornoCep = await servicoDeCeps.BuscarCepAsync(_key, cep);
            var endereco = retornoCep.Content;

            var tomador = new CadastrarTomador(empresa.cpf_cnpj, empresa.razao_social,
                new Endereco(endereco.municipio, endereco.bairro, endereco.cep, endereco.ibge, Estado.DF, endereco.logradouro, "S/N", TipoLogradouro.Rua));

            var resultado = await servico.CadastrarTomadorAsync(_key, tomador);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar Tomador - {resultado.Content.data.cnpj}");
        }

        private async Task<string> EmitirNotaV2(IServicosDeNFSe servico, IServicoDeCeps servicoDeCeps)
        {
            var idDeIntegracao = Guid.NewGuid().ToString();
            this._idDeIntegracao = idDeIntegracao;

            string cnpjPrestador = "28506113000182";

            var prestador = new EnviarPrestador(cnpjPrestador);

            string cnpjTomador = "31089572000112";

            var retorno = await servicoDeCeps.BuscarCepAsync(_key, "70701000");
            var buscaCep = retorno.Content;

            var endereco = new Endereco(buscaCep.municipio, "ASA NORTE", buscaCep.cep, buscaCep.ibge, Estado.DF,
                "Q SHN QUADRA 1 CONJUNTO A BL F SALAS 303 E 304 PARTE A", "S/N",
                TipoLogradouro.Rua);

            var tomador = new Tomador(cnpjTomador, "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL",
                "0787066000172", "teste@dfimoveis.com.br", endereco);

            var servicos = new List<Servico>();

            var iss = new Iss(TipoTributacao.TributavelForaDoMunicipio, Exibilidade.Exigivel, 5);
            var pis = new Pis(0.65);
            var cofins = new Cofins(3);

            var retencao = new Retencao(pis, cofins);

            var servico1 = new Servico("17.25", "17.25", "Plano de 10 imóveis", "6319400", iss, retencao, new Valor(1.50));
            var servico2 = new Servico("17.25", "17.25", "Destaque", "6319400", iss, retencao, new Valor(1.75));

            servicos.Add(servico1);
            servicos.Add(servico2);

            var lista = new List<CadastrarNFSe>();

            var cadastrarNFSE = new CadastrarNFSe(idDeIntegracao, prestador, tomador, servicos);

            lista.Add(cadastrarNFSE);


            string jsonString = JsonSerializer.Serialize(lista);

            var resultado = await servico.CadastrarAsync(_key, lista);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Emitir - {resultado}");

            return resultado.Content.documents.First().id;
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

            var valor = new Valor(1);

            var listaDeServicos = new List<Servico>();

            var servico = new Servico("0107", "Programação", "Programação de software", "00000",
                "4115200", "4115200", "MARINGA", iss, retencao, valor);

            listaDeServicos.Add(servico);

            var impressao = new Impressao(new CamposCustomizados("1", "1|2", "1|2|3"));

            var lista = new List<CadastrarNFSe>();

            var novaNota = new CadastrarNFSe(idDeIntegracao, null, tomador, listaDeServicos,
                impressao, true);

            lista.Add(novaNota);

            var resultado = await servicoNFSe.CadastrarAsync(_key, lista);

            var retorno = resultado.Content.documents.First().id;

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Emitir - {retorno}");

            return retorno;
        }

        private async Task BuscaResumoDaNota(IServicosDeNFSe servicoNFSe, string idIntegracao, string cnpj)
        {
            var resultado = await servicoNFSe.ConsultarResumoDaNota(_key, idIntegracao, cnpj);

            foreach (var item in resultado.Content)
            {
                Console.WriteLine($"consultar nota: {item.mensagem} ");
            }

        }

        private async Task BuscarNota(IServicosDeNFSe servicoNFSe, string notaId)
        {
            var resultado = await servicoNFSe.BuscarNotaAsync(_key, notaId);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Buscar - {resultado.Content.status}");
        }

        private async Task DownloadPDF(IServicosDeNFSe servicoNFSe, string notaId)
        {
            var resultado = await servicoNFSe.DownloadPDFAsync(_key, notaId);

            byte[] ByteArray = await resultado.Content.ReadAsByteArrayAsync();

            System.IO.Directory.CreateDirectory("pdf");

            System.IO.File.WriteAllBytes($"pdf/{notaId}.pdf", ByteArray);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Download PDF - {notaId}");
        }

        private async Task DownloadXML(IServicosDeNFSe servicoNFSe, string notaId)
        {
            var resultado = await servicoNFSe.DownloadXMLAsync(_key, notaId);

            byte[] ByteArray = await resultado.Content.ReadAsByteArrayAsync();

            System.IO.Directory.CreateDirectory("xml");

            System.IO.File.WriteAllBytes($"xml/{notaId}.xml", ByteArray);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Download XML - {notaId}");
        }

        private async Task<string> SolicitarCancelamento(IServicosDeNFSe servicoNFSe, string notaId)
        {
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
