using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos.Retornos
{
    public class RetornoCadastroDeEmpresa
    {
        public RetornoCadastroDeEmpresa()
        {
            this.data = new DataRetornoCadastroDeEmpresa();
        }

        public string message { get; set; }
        public DataRetornoCadastroDeEmpresa data { get; set; }
    }

    public class DataRetornoCadastroDeEmpresa
    {
        public string cnpj { get; set; }
    }


}
