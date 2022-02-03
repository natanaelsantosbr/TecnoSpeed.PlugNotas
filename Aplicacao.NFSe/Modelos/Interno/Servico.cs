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
