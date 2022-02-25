using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class CidadeIBGE
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public string padrao { get; set; }
        public bool certificado { get; set; }
        public bool multiservicos { get; set; }
        public bool login { get; set; }
        public bool senha { get; set; }
        public bool upload { get; set; }
        public bool sequencial { get; set; }
        public bool substituicao { get; set; }
        public int informacoesComplementares { get; set; }
        public int descricao { get; set; }
        public string fuso { get; set; }
    }
}
