using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.CertificadosDigitais.Retornos
{
    public class RetornoDeCadastroDeCD
    {
        public RetornoDeCadastroDeCD()
        {
            this.data = new DataRetornoDeCadastroDeCD();
        }

        public string message { get; set; }
        public DataRetornoDeCadastroDeCD data { get; set; }
    }

    public class DataRetornoDeCadastroDeCD
    {
        public string id { get; set; }
    }

}
