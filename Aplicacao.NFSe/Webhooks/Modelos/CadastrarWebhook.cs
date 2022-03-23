using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Webhooks.Modelos
{
    public class CadastrarWebhook
    {
        public CadastrarWebhook()
        {

        }

        public CadastrarWebhook(string url, Method method) : this()
        {
            this.url = url;
            this.method = method.ToString();
        }


        public string url { get; set; }

        public string method { get; set; }

    }
}
