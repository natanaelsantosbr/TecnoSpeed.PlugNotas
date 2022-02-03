using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Impressao
    {
        public Impressao()
        {
            this.camposCustomizados = new CamposCustomizados();
        }

        public Impressao(CamposCustomizados camposCustomizados)
        {
            this.camposCustomizados = camposCustomizados;
        }

        public CamposCustomizados camposCustomizados { get; set; }
    }
}
