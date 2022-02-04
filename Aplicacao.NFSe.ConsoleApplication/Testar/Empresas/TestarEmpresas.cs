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
            var endereco = new Endereco("Maringá", "87020-025", "Avenida", "Duque de Caxias",
                "Zona", "4115200", "17 andar", "PR", "882", "Zona 01");

            var telefone = new Telefone("44", "30379500");

            var rps = new Aplicacao.NFSe.Empresas.Modelos.Interno.Rps("1", 1, 1);

            var prefeitura = new Prefeitura("teste", "teste123");

            var email = new Email(true);

            var config = new ConfigEmpresa(true, rps, prefeitura, email);

            var nfse = new Nfse(true, 0, config);

            var empresa = new AlterarEmpresa("95383897000196", "8214100099", "1234567850", "Empresa do Natanael",
                "Empresa de Teste", _idCertificadoDigital, true, 1, true, true, 5, endereco, telefone, "empresa@natanael.com.br", nfse);

            var resultado = await servico.AlterarAsync(_key, id, empresa);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Alterar - {resultado.Content}");
        }

        private async Task<string> CadastrarEmpresa(IServicosDeEmpresas servico)
        {
            var endereco = new Endereco("Maringá", "87020-025", "Avenida", "Duque de Caxias",
                "Zona", "4115200", "17 andar", "PR", "882", "Zona 01");

            var telefone = new Telefone("44", "30379500");

            var rps = new Aplicacao.NFSe.Empresas.Modelos.Interno.Rps("1", 1, 1);

            var prefeitura = new Prefeitura("teste", "teste123");

            var email = new Email(true);

            var config = new ConfigEmpresa(true, rps, prefeitura, email);

            var nfse = new Nfse(true, 0, config);

            var empresa = new CadastrarEmpresa("95383897000196", "8214100099", "1234567850", "Empresa de Teste LTDA",
                "Empresa de Teste", _idCertificadoDigital, true, 1, true, true, 5, endereco, telefone, "empresa@plugnotas.com.br", nfse);

            var resultado = await servico.CadastrarAsync(_key, empresa);

            var id = resultado.Content.data.cnpj;

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Cadastrar - {id}");

            return id;
        }

        private async Task BuscarTodosOsCDs(IServicosDeEmpresas servicoEmpresas, string cnpj)
        {
            var resultado = await servicoEmpresas.BuscarPorCNPJAsync(_key, cnpj);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - Buscar por CNPJ - {resultado.Content.razaoSocial}");
        }
    }
}
