using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Professores
{
    public class Professor : IUsuario, ISenha
    {
        public string? CodigoCadastro { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? ProximaAlteracaoDeSenha { get; set; }
        public int QuantidadeDeLivrosEmprestados { get; set; }

        public Professor() { }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void PesquisarLivro(string livroBuscado)
        {
            throw new NotImplementedException();
        }

        public void AlterarSenhaMensal() { }

        public void ValidarSenha(string senha)
        {
            throw new NotImplementedException();
        }
    }
}
