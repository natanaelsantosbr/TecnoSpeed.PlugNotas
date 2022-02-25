using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos
{
    public class CadastrarWebhook
    {
        public CadastrarWebhook()
        {

        }

        public CadastrarWebhook(string url, Method method, QueryString queryString) : this()
        {
            this.url = url;
            this.method = method.ToString();
            this.queryString = queryString;
        }

        public string url { get; set; }

        public string method { get; set; }

        public QueryString queryString { get; set; }
    }
}
