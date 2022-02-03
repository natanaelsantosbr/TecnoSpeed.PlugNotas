using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Retornos.Cancelar
{
    public class RetornoDeConsultarCancelamento
    {
        public RetornoDeConsultarCancelamento()
        {
            this.data = new DataRetornoDeConsultarCancelamento();
        }

        public string message { get; set; }
        public DataRetornoDeConsultarCancelamento data { get; set; }
    }

    public class DataRetornoDeConsultarCancelamento
    {
        public string response { get; set; }
        public string protocol { get; set; }
    }

    
}
