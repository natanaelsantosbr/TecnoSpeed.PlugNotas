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

        public Tomador(string cpfCnpj, string razaoSocial, string nomeFantasia, string inscricaoMunicipal,
            string inscricaoEstadual, string email, Endereco endereco, Telefone telefone) : this()
        {
            this.cpfCnpj = cpfCnpj;
            this.razaoSocial = razaoSocial;
            this.nomeFantasia = nomeFantasia;
            this.inscricaoMunicipal = inscricaoMunicipal;
            this.inscricaoEstadual = inscricaoEstadual;
            this.email = email;
            this.endereco = endereco;
            this.telefone = telefone;
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
