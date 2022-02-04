using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos.Interno
{
    public class Nfe
    {
        public Nfe()
        {
            this.config = new ConfigEmpresa();
        }
        public bool ativo { get; set; }
        public int tipoContrato { get; set; }
        public ConfigEmpresa config { get; set; }
    }
}
