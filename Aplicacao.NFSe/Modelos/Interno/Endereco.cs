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

        public Endereco(string descricaoCidade, string bairro, string cep, string codigoCidade, Estado estado, 
            string logradouro, string numero, TipoLogradouro tipoLogradouro): this()
        {
            this.descricaoCidade = descricaoCidade;
            this.bairro = bairro;
            this.cep = cep;
            this.codigoCidade = codigoCidade;
            this.estado = estado.ToString();
            this.logradouro = logradouro;
            this.numero = numero;
            this.tipoLogradouro = tipoLogradouro.ToString();
        }

        public Endereco(string descricaoCidade, string cep, TipoLogradouro tipoLogradouro, string logradouro,
            TipoBairro tipoBairro, string codigoCidade, string complemento, Estado estado, string numero,
            string bairro) : this()
        {
            if (string.IsNullOrEmpty(bairro))
                throw new Exception("Bairro obrigatorio");

            if (string.IsNullOrEmpty(cep))
                throw new Exception("Cep obrigatorio");

            if (string.IsNullOrEmpty(codigoCidade))
                throw new Exception("Codigo da cidade obrigatorio");

            if (string.IsNullOrEmpty(logradouro))
                throw new Exception("Logradouro obrigatorio");

            if (string.IsNullOrEmpty(numero))
                throw new Exception("Numero obrigatorio");


            this.descricaoCidade = descricaoCidade;
            this.cep = cep;
            this.tipoLogradouro = tipoLogradouro.ToString();
            this.logradouro = logradouro;
            this.tipoBairro = tipoBairro.ToString();
            this.codigoCidade = codigoCidade;
            this.complemento = complemento;
            this.estado = estado.ToString();
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
