namespace Aplicacao.NFSe.Empresas.Modelos.Interno
{
    public class numeracao
    {
        public numeracao()
        {

        }
        public numeracao(int numero, string serie)
        {
            this.numero = numero;
            this.serie = serie;
        }

        public int numero { get; set; }
        public string serie { get; set; }
    }
}