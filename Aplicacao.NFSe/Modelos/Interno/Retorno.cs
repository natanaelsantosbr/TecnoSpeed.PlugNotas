using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Retorno
    {
        public string codigoVerificacao { get; set; }
        public DateTime dataAutorizacao { get; set; }
        public object dataCancelamento { get; set; }
        public string mensagemRetorno { get; set; }
        public string numeroNfse { get; set; }
        public string situacao { get; set; }
    }
}
