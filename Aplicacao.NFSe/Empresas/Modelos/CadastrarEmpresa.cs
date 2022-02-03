using Aplicacao.NFSe.Empresas.Modelos.Interno;
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
            this.nfe = new Nfe();
        }

        public string cpfCnpj { get; set; }
        public string inscricaoMunicipal { get; set; }
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
        public Nfe nfe { get; set; }        
    }
}
