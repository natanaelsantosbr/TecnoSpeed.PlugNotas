using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.NFSe.Modelos.Interno
{
    public class QueryString
    {
        public QueryString()
        {

        }

        public QueryString(string propertyName, string value) : this()
        {
            this.propertyName = propertyName;
            this.value = value;
        }

        public string propertyName { get; set; }

        public string value { get; set; }
    }
}
