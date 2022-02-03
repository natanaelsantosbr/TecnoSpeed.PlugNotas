using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class Iss
    {
        public Iss()
        {

        }

        public Iss(int exigibilidade, bool retido, int aliquota, 
            int aliquotaRetido, int tipoTributacao) : this()
        {
            this.exigibilidade = exigibilidade;
            this.retido = retido;
            this.aliquota = aliquota;
            this.aliquotaRetido = aliquotaRetido;
            this.tipoTributacao = tipoTributacao;
        }

        public int tipoTributacao { get; set; }
        public int exigibilidade { get; set; }
        public bool retido { get; set; }
        public int aliquota { get; set; }
        public int aliquotaRetido { get;  set; }
    }
}
