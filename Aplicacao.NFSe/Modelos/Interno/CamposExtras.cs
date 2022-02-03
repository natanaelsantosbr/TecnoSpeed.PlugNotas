using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class CamposExtras
    {
        public CamposExtras()
        {
            this.copiasEmail = new List<object>();
        }

        public List<object> copiasEmail { get; set; }
    }
}
