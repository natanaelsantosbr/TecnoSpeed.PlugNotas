using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Config
    {
        public Config()
        {
            this.rps = new Rps();
            this.email = new Email();
            this.logotipo = new Logotipo();
            this.integracoes = new List<object>();
        }
        public Rps rps { get; set; }
        public Email email { get; set; }
        public Logotipo logotipo { get; set; }
        public bool producao { get; set; }
        public List<object> integracoes { get; set; }
    }
}
