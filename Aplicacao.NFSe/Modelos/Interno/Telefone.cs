using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{

    public class Telefone
    {
        public Telefone()
        {

        }

        public Telefone(string ddd, string numero) : this()
        {
            this.ddd = ddd;
            this.numero = numero;
        }

        public string ddd { get; set; }
        public string numero { get; set; }
    }
}
