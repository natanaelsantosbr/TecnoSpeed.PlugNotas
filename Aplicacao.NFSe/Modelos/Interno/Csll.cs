using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Csll
    {
        public Csll()
        {

        }

        public Csll(int aliquota) : this()
        {
            this.aliquota = aliquota;
        }

        public int aliquota { get; set; }
    }
}
