using Aplicacao.NFSe.CertificadosDigitais;
using Aplicacao.NFSe.CertificadosDigitais.Modelos;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication.Testar.CertificadosDigitais
{
    public class TestarCertificadosDigitais : ITestarCertificadosDigitais
    {
        private string _url;
        private string _key;
        private string _grupo;

        public TestarCertificadosDigitais(string urlPadrao, string key, string grupo)
        {
            this._url = urlPadrao;
            this._key = key;
            this._grupo = grupo;
        }

        public async Task Inicializar()
        {
            var _servico = RestService.For<IServicosDeCertificadosDigitais>(_url);

            var id = await Upload(_servico);

            await BuscarPorId(_servico, id);

            await BuscarTodosOsCDs(_servico);
        }

        private async Task<string> Upload(IServicosDeCertificadosDigitais servico)
        {
            var file = @"C:\cds\DATAVK_SOFTWARE_E_INTERNET_EIRELI_29637776000107_1612553363140547000.pfx";

            var arquivoStream = File.OpenRead(file);

            StreamPart sp = new StreamPart(arquivoStream, file);

            var retorno = await servico.CadastrarAsync(_key, sp, "IU@mfA#!mO@");

            var id = retorno.Content.data.id;

            if (retorno != null)
                Console.WriteLine($"{_grupo} - upload - {id}");

            return id;
        }

        private async Task BuscarPorId(IServicosDeCertificadosDigitais servico, string id)
        {
            var resultado = await servico.BuscarPorIdAsync(_key, id);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - buscar id - {resultado.Content.nome}");
        }

        private async Task BuscarTodosOsCDs(IServicosDeCertificadosDigitais servico)
        {
            var resultado = await servico.BuscarTodosAsync(_key);

            if (resultado != null)
                Console.WriteLine($"{_grupo} - buscar todos");
        }
    }
}
