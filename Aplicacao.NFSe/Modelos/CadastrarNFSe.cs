using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos
{
    public class CadastrarNFSe
    {
        public CadastrarNFSe()
        {
            this.prestador = new Prestador();
            this.tomador = new Tomador();
            this.servico = new List<Servico>();
            this.impressao = new Impressao();
        }

        public CadastrarNFSe(string idIntegracao, Prestador prestador, Tomador tomador, List<Servico> servico) : this()
        {
            this.IdIntegracao = idIntegracao;
            this.prestador = prestador;
            this.tomador = tomador;
            this.servico = servico;
        }

        public CadastrarNFSe(string idIntegracao, Prestador prestador, Tomador tomador, List<Servico> servico, Impressao impressao, bool enviarEmail) : this()
        {
            this.IdIntegracao = idIntegracao;
            this.prestador = prestador;
            this.tomador = tomador;
            this.servico = servico;
            this.impressao = impressao;
            this.enviarEmail = enviarEmail;
        }

        public string IdIntegracao { get; set; }
        public Prestador prestador { get; set; }
        public Tomador tomador { get; set; }
        public List<Servico> servico { get; set; }
        public Impressao impressao { get; set; }
        public bool enviarEmail { get; set; }
    }
}
