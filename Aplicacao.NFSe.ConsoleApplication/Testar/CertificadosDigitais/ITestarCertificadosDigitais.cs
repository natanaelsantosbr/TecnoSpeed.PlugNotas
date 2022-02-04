using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.NFSe.ConsoleApplication.Testar.CertificadosDigitais
{
    public interface ITestarCertificadosDigitais
    {
        Task<string> Inicializar();
    }
}
