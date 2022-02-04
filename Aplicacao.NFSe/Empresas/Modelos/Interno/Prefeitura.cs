using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos.Interno
{
    public class Prefeitura
    {
        public Prefeitura()
        {

        }

        public Prefeitura(string login, string senha) : this()
        {
            this.login = login;
            this.senha = senha;
        }

        public string login { get; set; }
        public string senha { get; set; }
    }
}
