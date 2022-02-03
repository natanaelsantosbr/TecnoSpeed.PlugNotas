using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Endereco
    {
        public Endereco()
        {

        }

        public Endereco(string descricaoCidade, string cep, string tipoLogradouro, string logradouro, 
            string tipoBairro, string codigoCidade, string complemento, string estado, string numero,
            string bairro) : this()
        {
            this.descricaoCidade = descricaoCidade;
            this.cep = cep;
            this.tipoLogradouro = tipoLogradouro;
            this.logradouro = logradouro;
            this.tipoBairro = tipoBairro;
            this.codigoCidade = codigoCidade;
            this.complemento = complemento;
            this.estado = estado;
            this.numero = numero;
            this.bairro = bairro;
        }

        public string codigoPais { get; set; }
        public string descricaoPais { get; set; }
        public string descricaoCidade { get; set; }
        public string cep { get; set; }
        public string tipoLogradouro { get; set; }
        public string logradouro { get; set; }
        public string tipoBairro { get; set; }
        public string codigoCidade { get; set; }
        public string complemento { get; set; }
        public string estado { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
    }
}
