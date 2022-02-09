﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Endereco
    {
        public Endereco()
        {

        }

        public Endereco(string descricaoCidade, string cep, TipoLogradouro tipoLogradouro, string logradouro,
            TipoBairro tipoBairro, string codigoCidade, string complemento, Estado estado, string numero,
            string bairro) : this()
        {           

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
