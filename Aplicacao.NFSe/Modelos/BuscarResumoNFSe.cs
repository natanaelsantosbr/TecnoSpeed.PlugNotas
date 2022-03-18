using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos
{
    public class BuscarResumoNFSe
    {
        public BuscarResumoNFSe()
        {

        }
        public string id { get; set; }
        public string idIntegracao { get; set; }
        public string emissao { get; set; }
        public string tipoAutorizacao { get; set; }
        public string situacao { get; set; }
        public string prestador { get; set; }
        public string tomador { get; set; }
        public decimal valorServico { get; set; }
        public string serie { get; set; }
        public int numero { get; set; }
        public string mensagem { get; set; }
    }
}
