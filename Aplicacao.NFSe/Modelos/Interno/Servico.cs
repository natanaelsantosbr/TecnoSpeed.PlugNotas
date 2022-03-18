using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    
    public class Servico
    {
        public Servico()
        {
            this.iss = new Iss();
            this.valor = new Valor();
            this.retencao = new Retencao();
        }

        public Servico(string codigo, string codigoTributacao, string discriminacao,
            string cnae, Iss iss,  Retencao retencao, Valor valor) : this()
        {
            this.codigo = codigo;
            this.codigoTributacao = codigoTributacao;
            this.discriminacao = discriminacao;
            this.cnae = cnae;
            this.iss = iss;
            this.valor = valor;
            this.retencao = retencao;
        }

        public Servico(string codigo, string descricaoLC116, string discriminacao, string cnae,
            string codigoTributacao, string codigoCidadeIncidencia,
            string descricaoCidadeIncidencia,
            Iss iss, Retencao retencao, Valor valor) : this()
        {
            this.codigo = codigo;
            this.descricaoLC116 = descricaoLC116;
            this.discriminacao = discriminacao;
            this.cnae = cnae;
            this.codigoTributacao = codigoTributacao;
            this.codigoCidadeIncidencia = codigoCidadeIncidencia;
            this.descricaoCidadeIncidencia = descricaoCidadeIncidencia;
            this.iss = iss;
            this.retencao = retencao;
            this.valor = valor;
        }

        public Iss iss { get; set; }
        public Valor valor { get; set; }
        public Retencao retencao { get; set; }
        public bool tributosFederaisRetidos { get; set; }
        public string _id { get; set; }
        public string codigo { get; set; }
        public string descricaoLC116 { get; set; }
        public string discriminacao { get; set; }
        public string cnae { get; set; }
        public string codigoTributacao { get; set; }
        public string codigoCidadeIncidencia { get; set; }
        public string descricaoCidadeIncidencia { get; set; }
    }
}
