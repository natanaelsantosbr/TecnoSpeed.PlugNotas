using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Ceps.Modelos
{
    public class BuscarCep
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string municipio { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
    }
}
