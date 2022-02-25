using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Empresas.Modelos
{
    public class AlterarWebhook
    {
        public AlterarWebhook()
        {

        }

        public AlterarWebhook(string urlBase, Method method, QueryString queryString) : this()
        {
            this.url = urlBase; 
            this.method = method.ToString();
            this.queryString = queryString;
        }

        public string url { get; set; }

        public string method { get; set; }

        public QueryString queryString { get; set; }
    }
}
