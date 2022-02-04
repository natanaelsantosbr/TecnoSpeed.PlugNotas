using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Email
    {
        public Email()
        {

        }

        public Email(bool envio) : this()
        {
            this.envio = envio;
        }

        public bool envio { get; set; }
    }
}
