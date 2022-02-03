using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Pis
    {
        public Pis()
        {

        }

        public Pis(double aliquota) : this()
        {
            this.aliquota = aliquota;
        }

        public double aliquota { get; set; }
    }
}
