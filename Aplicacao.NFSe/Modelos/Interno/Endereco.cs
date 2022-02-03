using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Endereco
    {
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
