using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos.Interno
{
    public class Nfe
    {
        public Nfe()
        {
            this.config = new Config();
        }
        public bool ativo { get; set; }
        public int tipoContrato { get; set; }
        public Config config { get; set; }
    }
}
