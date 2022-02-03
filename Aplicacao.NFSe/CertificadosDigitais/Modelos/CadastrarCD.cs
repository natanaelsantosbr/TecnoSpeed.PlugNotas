using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.CertificadosDigitais.Modelos
{
    public class CadastrarCD
    {
        public CadastrarCD()
        {

        }

        public CadastrarCD(string arquivo, string senha, string email) : this()
        {
            this.arquivo = arquivo;
            this.senha = senha;
            this.email = email;
        }

        public string arquivo { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
    }
}
