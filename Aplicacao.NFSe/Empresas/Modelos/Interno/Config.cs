using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos.Interno
{
    public class Config
    {
        public Config()
        {
            this.rps = new Rps();
            this.prefeitura = new Prefeitura();
            this.email = new Email();
        }

        public bool producao { get; set; }
        public Rps rps { get; set; }
        public Prefeitura prefeitura { get; set; }
        public Email email { get; set; }
        public bool impressaoFcp { get; set; }
        public bool impressaoPartilha { get; set; }
        public int serie { get; set; }
        public int numero { get; set; }
    }
}
