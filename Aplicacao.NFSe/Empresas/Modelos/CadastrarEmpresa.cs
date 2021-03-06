using Aplicacao.NFSe.Empresas.Modelos.Interno;
using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos
{
    public class CadastrarEmpresa
    {
        public CadastrarEmpresa()
        {
            this.endereco = new Endereco();
            this.telefone = new Telefone();
            this.nfse = new Nfse();
        }

        public CadastrarEmpresa(string cpfCnpj, string inscricaoEstadual,
            string razaoSocial, string nomeFantasia,
            string certificado, SimplesNacional simplesNacional, RegimeTributario regimeTributario, IncentivoFiscal incentivoFiscal,
            IncentivadorCultural incentivadorCultural,
            RegimeTributarioEspecial regimeTributarioEspecial, Endereco endereco, 
            Telefone telefone, string email, Nfse nfse) : this()
        {
            if (string.IsNullOrEmpty(cpfCnpj))
                throw new Exception("CNPJ obrigatório");

            if (string.IsNullOrEmpty(inscricaoEstadual))
                throw new Exception("Inscricação Estadual obrigatório");


            this.cpfCnpj = cpfCnpj;
            this.inscricaoEstadual = inscricaoEstadual;
            this.razaoSocial = razaoSocial;
            this.nomeFantasia = nomeFantasia;
            this.certificado = certificado;

            this.simplesNacional = simplesNacional == SimplesNacional.Sim ? true : false;
            this.regimeTributario = (int)regimeTributario;
            this.incentivoFiscal = incentivoFiscal == IncentivoFiscal.Sim ? true : false;
            this.incentivadorCultural = incentivadorCultural == IncentivadorCultural.Sim ? true : false;
            this.regimeTributarioEspecial = (int)regimeTributarioEspecial;
            this.endereco = endereco;
            this.telefone = telefone;
            this.email = email;
            this.nfse = nfse;
        }

        public string cpfCnpj { get; set; }        
        public string inscricaoEstadual { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string certificado { get; set; }
        public bool simplesNacional { get; set; }
        public int regimeTributario { get; set; }
        public bool incentivoFiscal { get; set; }
        public bool incentivadorCultural { get; set; }
        public int regimeTributarioEspecial { get; set; }
        public string email { get; set; }
        public Endereco endereco { get; set; }
        public Telefone telefone { get; set; }
        public Nfse nfse { get; set; }
    }
}
