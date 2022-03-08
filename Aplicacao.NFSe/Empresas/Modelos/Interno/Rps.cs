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

        public Rps(int lote, string serie, int numero)
        {
            this.lote = lote;
            this.serie = serie;
            this.numero = numero;
        }

        public string serie { get; set; }
        public int numero { get; set; }
        public int lote { get; set; }
    }
}
