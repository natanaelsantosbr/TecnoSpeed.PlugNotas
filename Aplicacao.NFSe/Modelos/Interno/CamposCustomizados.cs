using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class CamposCustomizados
    {
        public CamposCustomizados()
        {

        }

        public CamposCustomizados(string a, string b, string c) : this()
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
    }
}
