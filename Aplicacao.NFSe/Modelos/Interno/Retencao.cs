using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Retencao
    {
        public Retencao()
        {
            this.pis = new Pis();
            this.cofins = new Cofins();
            this.csll = new Csll();
        }

        public Pis pis { get; set; }
        public Cofins cofins { get; set; }
        public Csll csll { get; set; }
    }
}
