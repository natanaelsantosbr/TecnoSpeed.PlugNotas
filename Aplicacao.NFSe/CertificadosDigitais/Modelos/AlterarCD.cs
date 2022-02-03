using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.CertificadosDigitais.Modelos
{
    public class AlterarCD    
    {
        public string idCertificado { get; set; }
        public string arquivo { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
    }
}
