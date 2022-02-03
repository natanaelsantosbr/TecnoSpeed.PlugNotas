using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class TipoDeCancelamento
    {
        public TipoDeCancelamento()
        {

        }

        public TipoDeCancelamento(string codigo, string message)
        {
            this.codigo = codigo;
            this.message = message;
        }

        public string codigo { get; set; }

        public string message { get; set; }
    }
}
