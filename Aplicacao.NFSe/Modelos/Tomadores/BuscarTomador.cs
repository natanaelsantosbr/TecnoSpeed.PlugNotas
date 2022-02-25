using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Tomadores
{
    public class BuscarTomador
    {
        public BuscarTomador()
        {

        }

        public string cpfCnpj { get; set; }
        public string razaoSocial { get; set; }
        public Endereco endereco { get; set; }
        public string email { get; set; }
        public string inscricaoEstadual { get; set; }
        public string inscricaoMunicipal { get; set; }
        public string inscricaoSuframa { get; set; }
        public string nomeFantasia { get; set; }
        public bool orgaoPublico { get; set; }
        public Telefone telefone { get; set; }
        public int indicadorInscricaoEstadual { get; set; }
    }
}
