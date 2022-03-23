using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Webhooks.Modelos
{
    public class AlterarWebhook
    {
        public AlterarWebhook()
        {

        }

        public AlterarWebhook(string url, Method method) : this()
        {
            this.url = url;
            this.method = method.ToString();
        }


        public string url { get; set; }

        public string method { get; set; }

    }
}
