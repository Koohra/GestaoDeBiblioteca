using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosBiblioteca.Interfaces;

namespace UsuariosBiblioteca.Professores
{
    internal class Professor : IUsuario, ISenha
    {
        public string? CodigoCadastro { get; private set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public DateTime ProximaAlteracaoDeSenha { get; set; }
        public int QuantidadeDeLivrosEmprestados { get; private set; }

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
