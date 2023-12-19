namespace UsuariosBiblioteca
{
    public abstract class Usuario
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public Usuario(string nome)
        {
            Nome = nome;
        }

        public virtual void PesquisarLivro()
        {
            //implementar
        }
    }
}
