using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos.Interno
{
    public class ConfigEmpresa
    {
        public ConfigEmpresa()
        {

        }

        public ConfigEmpresa(bool producao, Rps rps, Email email)
        {
            this.producao = producao;
            this.rps = rps;
            this.prefeitura = prefeitura;
            this.email = email;
        }

        public bool producao { get; set; }
        public Rps rps { get; set; }
        public Prefeitura prefeitura { get; set; }
        public Email email { get; set; }
    }
}
