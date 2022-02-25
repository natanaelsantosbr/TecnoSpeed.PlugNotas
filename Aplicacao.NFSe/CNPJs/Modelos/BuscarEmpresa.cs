using Aplicacao.NFSe.CNPJs.Modelos.Interno;
using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.CNPJs.Modelos
{
    public class BuscarEmpresa
    {
        public string data_situacao { get; set; }
        public string situacao { get; set; }
        public DateTime ultima_atualizacao { get; set; }
        public string natureza_juridica { get; set; }
        public string cpf_cnpj { get; set; }
        public string telefone { get; set; }
        public string status { get; set; }
        public List<Socio> socios { get; set; }
        public string email { get; set; }
        public string tipo { get; set; }
        public string capital_social { get; set; }
        public string data_abertura { get; set; }
        public bool cached { get; set; }
        public string razao_social { get; set; }
        public Endereco endereco { get; set; }
        public string nome { get; set; }
        public List<Atividade> atividades { get; set; }
    }
}
