using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Cofins
    {
        public Cofins()
        {

        }

        public Cofins(int aliquota) : this()
        {
            this.aliquota = aliquota;
        }

        public int aliquota { get; set; }
    }
}
