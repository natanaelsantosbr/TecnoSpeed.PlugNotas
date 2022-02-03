using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Retornos.Cancelar
{
    public class RetornoDeSolicitacaoDeCancelamento
    {
        public RetornoDeSolicitacaoDeCancelamento()
        {
            this.data = new DataRetornoDeSolicitacaoDeCancelamento();
        }

        public string message { get; set; }
        public DataRetornoDeSolicitacaoDeCancelamento data { get; set; }
    }

    public class DataRetornoDeSolicitacaoDeCancelamento
    {
        public string protocol { get; set; }
    }
}
