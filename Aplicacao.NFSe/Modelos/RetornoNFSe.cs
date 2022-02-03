
using Aplicacao.NFSe.Modelos.Interno;
using System.Collections.Generic;

namespace Aplicacao.NFSe.Modelos
{
    public class RetornoNFSe
    {
        public RetornoNFSe()
        {
            this.documents = new List<Document>();
        }

        public List<Document> documents { get; set; }
        public string message { get; set; }
        public string protocol { get; set; }
    }    
}
