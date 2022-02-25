using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Tomadores
{
    public class AlterarTomador
    {
        public AlterarTomador()
        {

        }

        public AlterarTomador(string cpfCnpj, string razaoSocial, Endereco endereco) : this()
        {
            this.cpfCnpj = cpfCnpj;
            this.razaoSocial = razaoSocial;
            this.endereco = endereco;
        }

        public string cpfCnpj { get; set; }
        public string razaoSocial { get; set; }
        public Endereco endereco { get; set; }
    }
}
