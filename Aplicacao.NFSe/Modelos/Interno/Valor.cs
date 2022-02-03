
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Valor
    {
        public int deducoes { get; set; }
        public double baseCalculo { get; set; }
        public int servico { get; set; }
        public int descontoIncondicionado { get; set; }
        public int descontoCondicionado { get; set; }
        public double liquido { get; set; }
    }
}
