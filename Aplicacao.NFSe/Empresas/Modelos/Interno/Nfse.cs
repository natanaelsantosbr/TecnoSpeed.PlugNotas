using Aplicacao.NFSe.Modelos.Interno;
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

        public Nfse(Ativar ativar, TipoContrato tipoContrato, ConfigEmpresa config) : this()
        {
            this.ativo = ativar == Ativar.Sim ? true : false;
            this.tipoContrato = (int)tipoContrato;
            this.config = config;
        }

        public bool ativo { get; set; }
        public int tipoContrato { get; set; }
        public ConfigEmpresa config { get; set; }
    }
}
