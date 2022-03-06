
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

        public Valor(int deducoes, double baseCalculo, double servico, int descontoIncondicionado,
            int descontoCondicionado, double liquido ) : this()
        {
            this.deducoes = deducoes;
            this.baseCalculo = baseCalculo;
            this.servico = servico;
            this.descontoIncondicionado = descontoIncondicionado;
            this.descontoCondicionado = descontoCondicionado;
            this.liquido = liquido;
        }

        public int deducoes { get; set; }
        public double baseCalculo { get; set; }
        public double servico { get; set; }
        public int descontoIncondicionado { get; set; }
        public int descontoCondicionado { get; set; }
        public double liquido { get; set; }
    }
}
