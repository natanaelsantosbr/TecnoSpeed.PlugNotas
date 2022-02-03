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
        public Telefone telefone { get; set; }
        public Config config { get; set; }
        public Endereco endereco { get; set; }
        public bool incentivadorCultural { get; set; }
        public bool incentivoFiscal { get; set; }
        public string cpfCnpj { get; set; }
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
