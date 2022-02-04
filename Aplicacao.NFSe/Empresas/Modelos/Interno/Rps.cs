using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos.Interno
{
    public class Rps
    {
        public Rps()
        {

        }

        public Rps(string serie, int numero, int lote)
        {
            this.serie = serie;
            this.numero = numero;
            this.lote = lote;
        }

        public string serie { get; set; }
        public int numero { get; set; }
        public int lote { get; set; }
    }
}
