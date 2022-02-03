using Aplicacao.NFSe.Modelos.Interno;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos
{
    public class BuscarNFSe
    {
        public BuscarNFSe()
        {
            this.rps = new Rps();
            this.camposExtras = new CamposExtras();
            this.prestador = new Prestador();
            this.tomador = new Tomador();
            this.pdf = new Pdf();
            this.xml = new Xml();
            this.retorno = new Retorno();
            this.cancelamento = new Cancelamento();
            this.cidadePrestacao = new CidadePrestacao();
            this.impressao = new Impressao();
            this.servico = new List<Servico>();
            this.webhook = new List<object>();
            this.parcelas = new List<object>();
        }

        public Rps rps { get; set; }
        public CamposExtras camposExtras { get; set; }
        public Prestador prestador { get; set; }
        public Tomador tomador { get; set; }
        public Pdf pdf { get; set; }
        public Xml xml { get; set; }
        public Retorno retorno { get; set; }
        public Cancelamento cancelamento { get; set; }
        public CidadePrestacao cidadePrestacao { get; set; }
        public Impressao impressao { get; set; }
        public List<Servico> servico { get; set; }
        public List<object> webhook { get; set; }
        public List<object> parcelas { get; set; }
        public bool substituicao { get; set; }
        public int tentativasReenvio { get; set; }
        public bool enviarEmail { get; set; }
        public string tipoAutorizacao { get; set; }
        public string protocol { get; set; }
        public string status { get; set; }
        
        public string id { get; set; }
        public string numeroNfse { get; set; }
    }





















   











    










}
