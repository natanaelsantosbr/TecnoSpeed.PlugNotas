using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos.Interno
{
    public class Nfse
    {
        public Nfse()
        {
            this.config = new ConfigEmpresa();
        }

        public Nfse(bool ativo, int tipoContrato, ConfigEmpresa config) : this()
        {
            this.ativo = ativo;
            this.tipoContrato = tipoContrato;
            this.config = config;
        }

        public bool ativo { get; set; }
        public int tipoContrato { get; set; }
        public ConfigEmpresa config { get; set; }
    }
}
