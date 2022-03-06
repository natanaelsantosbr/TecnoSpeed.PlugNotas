using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{

    
    public class Prestador
    {
        public Prestador()
        {
            this.telefone = new Telefone();
            this.config = new Config();
            this.endereco = new Endereco();
        }

        public Prestador(string cpfCnpj)
        {
            this.cpfCnpj = cpfCnpj;
        }

        public Prestador(string cpfCnpj,  string razaoSocial, string nomeFantasia, string inscricaoMunicipal,
            string inscricaoEstadual, bool simplesNacional, bool incentivoFiscal,
            bool incentivadorCultural, int regimeTributario, int regimeTributarioEspecial,
            string email, Endereco endereco, Telefone telefone) : this()
        {
            this.cpfCnpj = cpfCnpj;
            this.razaoSocial = razaoSocial;
            this.nomeFantasia = nomeFantasia;
            this.inscricaoMunicipal = inscricaoMunicipal;
            this.inscricaoEstadual = inscricaoEstadual;
            this.simplesNacional = simplesNacional;
            this.incentivoFiscal = incentivoFiscal;
            this.incentivadorCultural = incentivadorCultural;
            this.regimeTributario = regimeTributario;
            this.regimeTributarioEspecial = regimeTributarioEspecial;
            this.email = email;
            this.endereco = endereco;
            this.telefone = telefone;
        }

        public Telefone telefone { get; set; }
        public Config config { get; set; }
        public Endereco endereco { get; set; }
        public bool incentivadorCultural { get; set; }
        public bool incentivoFiscal { get; set; }
        public string cpfCnpj { get; set; }
        public string codigoEstrangeiro { get; set; }
        public string inscricaoEstadual { get; set; }
        public string inscricaoMunicipal { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public bool simplesNacional { get; set; }
        public int regimeTributario { get; set; }
        public int regimeTributarioEspecial { get; set; }
        public string email { get; set; }
        public string certificado { get; set; }
    }
}
