
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Valor
    {
        public Valor()
        {

        }

        public Valor(double servico) : this()
        {
            this.servico = servico;
        }

        public double servico { get; set; }
    }
}
