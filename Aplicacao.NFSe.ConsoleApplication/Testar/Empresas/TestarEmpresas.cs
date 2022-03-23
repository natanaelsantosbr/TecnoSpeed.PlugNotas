using Aplicacao.NFSe.Ceps;
using Aplicacao.NFSe.Empresas;
using Aplicacao.NFSe.Empresas.Modelos;
using Aplicacao.NFSe.Empresas.Modelos.Interno;
using Aplicacao.NFSe.Modelos.Interno;
using Aplicacao.NFSe.Webhooks;
using Aplicacao.NFSe.Webhooks.Modelos;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication.Testar.Empresas
{
    public class TestarEmpresas : ITestarEmpresas
    {
        private const string UrlPadrao = "https://adm.dfimoveis.com.br/plugnotas";
        private string _url;
        private string _key;
        private string _grupo;
        private string _idCertificadoDigital;

        public TestarEmpresas(string urlPadrao, string key, string grupo)
        {
            this._url = urlPadrao;
            this._key = key;
            this._grupo = grupo;
        }

        public async Task Inicializar(string idCertificadoDigital)
        {
            this._idCertificadoDigital = idCertificadoDigital;

            var servico = RestService.For<IServicosDeEmpresas>(_url);
            var servicoDeCeps = RestService.For<IServicoDeCeps>(_url);
            var servicoDeWebhook = RestService.For<IServicosDeWebhooks>(_url);

            //var id =  await CadastrarEmpresa(servico, servicoDeCeps);

            var cnpj = "28506113000182";

            //await AlterarEmpresa(servico, servicoDeCeps, cnpj);

            //await CadastrarLogotipo(servico, cnpj);

            //await DownloadLogotipo(servico, cnpj);

            //await BuscarTodosOsCDs(servico, cnpj);            

            //await ExcluirLogotipo(servico, cnpj);

            await TestarWebHooks(servicoDeWebhook, cnpj);

            //await BuscarWebhook(servico, cnpj);
        }

        private async Task TestarWebHooks(IServicosDeWebhooks servicoDeWebhook, string cnpj)
        {
            //await CadastrarWebhook(servicoDeWebhook);

            await ConsultarWebhook(servicoDeWebhook);            

            await AlterarWebhook(servicoDeWebhook);

            await TestarWebhook(servicoDeWebhook);

            //await ExcluirWebhook(servicoDeWebhook);           

            
        }

        private async Task AlterarEmpresa(IServicosDeEmpresas servico, IServicoDeCeps servicoDeCeps, string id)
        {
            CadastrarEmpresa empresa = await this.CriarEmpresa(servicoDeCeps);

            string jsonString = JsonSerializer.Serialize(empresa);

            var resultado = await servico.AlterarAsync(_key, id, empresa);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Alterar - {resultado.Content}");
        }

        private async Task<string> CadastrarEmpresa(IServicosDeEmpresas servico, IServicoDeCeps servicoDeCeps)
        {
            CadastrarEmpresa empresa = await CriarEmpresa(servicoDeCeps);

            var resultado = await servico.CadastrarAsync(_key, empresa);
            
            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar - {empresa.cpfCnpj}");

            return empresa.cpfCnpj;
        }

        private async Task<CadastrarEmpresa> CriarEmpresa(IServicoDeCeps servicoDeCeps)
        {
            var retorno = await servicoDeCeps.BuscarCepAsync(_key, "70070120");

            var buscaCep = retorno.Content;

            var endereco = new Endereco("BRASILIA", buscaCep.cep, TipoLogradouro.Avenida, "Q SBS QUADRA 2",
                            TipoBairro.Setor, buscaCep.ibge, "BLOCO E SALA 1504 PARTE 1",
                            Estado.DF, "S/N", "ASA SUL");

            var telefone = new Telefone("61", "981145923");

            var rps = new Aplicacao.NFSe.Empresas.Modelos.Interno.Rps(1, "2", 2);

            var email = new Email(true);

            var config = new ConfigEmpresa(TipoDeAmbiente.Producao, rps, email);

            var nfse = new Nfse(Ativar.Sim, TipoContrato.Bilhetagem, config);

            var empresa = new CadastrarEmpresa("28506113000182",  "0782454100115", "DF IMOVEIS.COM S/A",
                "DFIMOVEIS.COM", _idCertificadoDigital, SimplesNacional.Nao, RegimeTributario.NormalPresumindo, IncentivoFiscal.Nao,
                 IncentivadorCultural.Nao, RegimeTributarioEspecial.SemRegimeTributarioEspecial,
                 endereco, telefone, "teste@dfimoveis.com.br", nfse);

            return empresa;
        }

        private async Task BuscarTodosOsCDs(IServicosDeEmpresas servicoEmpresas, string cnpj)
        {
            var resultado = await servicoEmpresas.BuscarPorCNPJAsync(_key, cnpj);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Buscar por CNPJ - {resultado.Content.razaoSocial}");
        }

        private async Task CadastrarLogotipo(IServicosDeEmpresas servicoEmpresas, string cnpj)
        {
            var file = @"C:\cds\img\dfimoveis.jpg";

            var arquivoStream = File.OpenRead(file);

            StreamPart sp = new StreamPart(arquivoStream, file);

            var resultado = await servicoEmpresas.UploadLogotipoAsync(_key, sp, cnpj);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar logotipo por CNPJ - {resultado.Content}");
        }

        private async Task DownloadLogotipo(IServicosDeEmpresas servicoEmpresas, string cnpj)
        {
            var resultado = await servicoEmpresas.DownloadLogotipoAsync(_key, cnpj);

            byte[] ByteArray = await resultado.Content.ReadAsByteArrayAsync();

            System.IO.Directory.CreateDirectory("logos");

            System.IO.File.WriteAllBytes($"logos/{cnpj}.jpg", ByteArray);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar logotipo por CNPJ - {resultado.Content}");
        }

        private async Task ExcluirLogotipo(IServicosDeEmpresas servicoEmpresas, string cnpj)
        {
            var resultado = await servicoEmpresas.ExcluirLogotipoAsync(_key, cnpj);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar logotipo por CNPJ - {resultado.Content}");
        }

        private async Task CadastrarWebhook(IServicosDeWebhooks servicosDeWebhooks)
        {
            string url = UrlPadrao;

            var resultado = await servicosDeWebhooks.CadastrarAsync(_key, new CadastrarWebhook(url, Method.Post));

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar Webhook por CNPJ - {resultado.Content.message}");
        }

        private async Task AlterarWebhook(IServicosDeWebhooks servicosDeWebhooks)
        {
            string url = UrlPadrao;

            var resultado = await servicosDeWebhooks.AlterarSync(_key, new AlterarWebhook(url, Method.Post));

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Alterar Webhook por CNPJ - {resultado.Content.message}");
        }

        private async Task ConsultarWebhook(IServicosDeWebhooks servicosDeWebhooks)
        {
            var resultado = await servicosDeWebhooks.ConsultarSync(_key);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Testar Webhook por CNPJ - {resultado.Content}");
        }

        private async Task TestarWebhook(IServicosDeWebhooks servicosDeWebhooks)
        {
            var resultado = await servicosDeWebhooks.TestarSync(_key);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Testar Webhook por CNPJ - {resultado}");
        }

        

        private async Task ExcluirWebhook(IServicosDeWebhooks servicosDeWebhooks)
        {
            var resultado = await servicosDeWebhooks.ExcluirSync(_key);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Excluir Webhook por CNPJ - {resultado.Content}");
        }

        private async Task BuscarWebhook(IServicosDeWebhooks servicosDeWebhooks)
        {
            var resultado = await servicosDeWebhooks.ConsultarSync(_key);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Buscar Webhook por CNPJ - {resultado.Content}");
        }
    }
}
