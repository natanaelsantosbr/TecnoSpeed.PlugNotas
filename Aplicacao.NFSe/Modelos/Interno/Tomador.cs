using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Tomador
    {
        public Tomador()
        {
            this.telefone = new Telefone();
            this.endereco = new Endereco();
        }

        public Telefone telefone { get; set; }
        public Endereco endereco { get; set; }
        public string cpfCnpj { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string inscricaoMunicipal { get; set; }
        public string inscricaoEstadual { get; set; }
        public string email { get; set; }
    }
}
