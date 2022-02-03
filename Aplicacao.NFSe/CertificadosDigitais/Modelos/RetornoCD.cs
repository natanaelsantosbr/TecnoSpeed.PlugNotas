using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.CertificadosDigitais.Modelos
{
    public class RetornoCD
    {
        public RetornoCD()
        {
            this.data = new Data();
        }

        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
    }
}
