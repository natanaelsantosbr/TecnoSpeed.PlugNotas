using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Rps
    {
        public Rps()
        {
            this.numeracao = new List<object>();
        }
        public int dataEmissaoTz { get; set; }
        public int dataVencimentoTz { get; set; }
        public int competenciaTz { get; set; }
        public string tipo { get; set; }
        public int lote { get; set; }
        public string serie { get; set; }
        public DateTime dataEmissao { get; set; }
        public int numero { get; set; }
        public DateTime dataVencimento { get; set; }
        public List<object> numeracao { get; set; }
    }
}
