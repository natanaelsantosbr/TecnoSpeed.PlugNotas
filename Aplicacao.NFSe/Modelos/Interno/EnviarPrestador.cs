namespace Aplicacao.NFSe.Modelos.Interno
{
    public class EnviarPrestador
    {
        
        public EnviarPrestador()
        {

        }

        public EnviarPrestador(string cpfCnpj) : this()
        {
            this.cpfCnpj = cpfCnpj;
        }

        public string cpfCnpj { get; set; }
    }
}