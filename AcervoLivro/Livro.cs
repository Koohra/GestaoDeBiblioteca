namespace ControleDoAcervo
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor {  get; set; }
        public int AnoPublicacao { get; set; }
        public int QuantitadeExemplares { get; set; }
        public string Setor {  get; set; }
        public List<string> ListaDeReserva { get; set;}

        public Livro()
        {

        }

    }
}
