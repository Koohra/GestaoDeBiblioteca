namespace UsuariosBiblioteca.Funcionarios
{
    public class Bibliotecario : Funcionario
    {
        public Bibliotecario(string codigoCadastro, string nome, string email, string senha) : base(codigoCadastro, nome, email, senha) 
        {
            Cargo = Cargos.Bibliotecario;
        }
    }
}
