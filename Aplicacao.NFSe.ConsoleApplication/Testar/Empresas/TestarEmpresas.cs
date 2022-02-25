using Aplicacao.NFSe.Empresas;
using Aplicacao.NFSe.Empresas.Modelos;
using Aplicacao.NFSe.Empresas.Modelos.Interno;
using Aplicacao.NFSe.Modelos.Interno;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication.Testar.Empresas
{
    public class TestarEmpresas : ITestarEmpresas
    {
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

            //var id =  await CadastrarEmpresa(servico);

            var cnpj = "28506113000182";

            await AlterarEmpresa(servico, cnpj);

            await BuscarTodosOsCDs(servico, cnpj);

            await CadastrarLogotipo(servico, cnpj);

            await DownloadLogotipo(servico, cnpj);

            await ExcluirLogotipo(servico, cnpj);

            await ExcluirWebhook(servico, cnpj);

            await CadastrarWebhook(servico, cnpj);

            await AlterarWebhook(servico, cnpj);

            await BuscarWebhook(servico, cnpj);
        }

        private async Task AlterarEmpresa(IServicosDeEmpresas servico, string id)
        {
            CadastrarEmpresa empresa = this.CriarEmpresa();

            empresa.nomeFantasia = "Empresa MMMMM";

            var resultado = await servico.AlterarAsync(_key, id, empresa);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Alterar - {resultado.Content}");
        }

        private async Task<string> CadastrarEmpresa(IServicosDeEmpresas servico)
        {
            CadastrarEmpresa empresa = CriarEmpresa();

            var resultado = await servico.CadastrarAsync(_key, empresa);

            var id = resultado.Content.data.cnpj;

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar - {id}");

            return id;
        }

        private CadastrarEmpresa CriarEmpresa()
        {
            var endereco = new Endereco("BRASILIA", "70070120", TipoLogradouro.Avenida, "Q SBS QUADRA 2",
                            TipoBairro.Setor, "5300108", "BLOCO E SALA 1504 PARTE 1", Estado.DF, "S/N", "ASA SUL");

            var telefone = new Telefone("61", "992394399");

            var rps = new Aplicacao.NFSe.Empresas.Modelos.Interno.Rps("1", 1, 1);

            var email = new Email(true);

            var config = new ConfigEmpresa(TipoDeAmbiente.Homologacao, rps, email);

            var nfse = new Nfse(Ativar.Sim, 0, config);

            var empresa = new CadastrarEmpresa("28506113000182", "07.824.541/001-15", "0782454100115", "DF IMOVEIS.COM S/A",
                "DFIMOVEIS.COM", _idCertificadoDigital, SimplesNacional.Nao, RegimeTributario.NormalPresumindo, IncentivoFiscal.Nao,
                 IncentivadorCultural.Nao, RegimeTributarioEspecial.SemRegimeTributarioEspecial, endereco, telefone, "contato@dfimoveis.com.br", nfse);

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

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar logotipo por CNPJ - {resultado.Content}");
        }

        private async Task ExcluirLogotipo(IServicosDeEmpresas servicoEmpresas, string cnpj)
        {
            var resultado = await servicoEmpresas.ExcluirLogotipoAsync(_key, cnpj);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar logotipo por CNPJ - {resultado.Content}");
        }

        private async Task CadastrarWebhook(IServicosDeEmpresas servicoEmpresas, string cnpj)
        {
            string url = "https://api.adm.dfimoveis.com.br/plugnotas";

            var queryString = new QueryString("cnpj", cnpj);

            var resultado = await servicoEmpresas.CadastrarWebhookAsync(_key, cnpj, new CadastrarWebhook(url, Method.Post, queryString));

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar Webhook por CNPJ - {resultado.Content.message}");
        }

        private async Task AlterarWebhook(IServicosDeEmpresas servicoEmpresas, string cnpj)
        {
            string url = "https://api.adm.dfimoveis.com.br/plugnotas";

            var queryString = new QueryString("cnpj", cnpj);

            var resultado = await servicoEmpresas.AlterarWebhookAsync(_key, cnpj, new AlterarWebhook(url, Method.Post, queryString));

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Alterar Webhook por CNPJ - {resultado.Content.message}");
        }

        private async Task ExcluirWebhook(IServicosDeEmpresas servicoEmpresas, string cnpj)
        {
            var resultado = await servicoEmpresas.ExcluirWebhookAsync(_key, cnpj);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Excluir Webhook por CNPJ - {resultado.Content}");
        }

        private async Task BuscarWebhook(IServicosDeEmpresas servicoEmpresas, string cnpj)
        {
            var resultado = await servicoEmpresas.BuscarWebhookAsync(_key, cnpj);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Buscar Webhook por CNPJ - {resultado.Content}");
        }
    }
}
