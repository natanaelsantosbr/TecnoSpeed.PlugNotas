using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.CertificadosDigitais.Modelos
{
    public class BuscarCD
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string hash { get; set; }
        public string vencimento { get; set; }
        public string email { get; set; }
    }
}
