using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosBiblioteca
{
    internal class Professor
    {
        public string? CodigoCadastro { get; private set; }
        //public string Nome { get; set; }
        //public string Email { get; set; }
        public string? SenhaPadrao { get; set; }
        public DateTime ultimaAlteracaoDeSenha { get; set; }  //neste tipo da pra setar apenas a data?
        public DateTime dataNovaAlteracaoSenha { get; set; }
        public int QuantidadeDeLivrosEmprestados { get; private set; }
    }
}
