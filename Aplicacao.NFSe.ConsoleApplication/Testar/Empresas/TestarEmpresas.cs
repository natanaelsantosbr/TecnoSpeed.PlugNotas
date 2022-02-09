using Aplicacao.NFSe.Empresas;
using Aplicacao.NFSe.Empresas.Modelos;
using Aplicacao.NFSe.Empresas.Modelos.Interno;
using Aplicacao.NFSe.Modelos.Interno;
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

            var id =  await CadastrarEmpresa(servico);

            await AlterarEmpresa(servico, id);

            await BuscarTodosOsCDs(servico, id);
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

            var config = new ConfigEmpresa(true, rps, email);

            var nfse = new Nfse(true, 0, config);

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
    }
}
