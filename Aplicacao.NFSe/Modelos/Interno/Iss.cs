using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Iss
    {
        public int tipoTributacao { get; set; }
        public int exigibilidade { get; set; }
        public bool retido { get; set; }
        public int aliquota { get; set; }
    }
}
