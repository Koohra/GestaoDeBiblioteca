//namespace InterfaceUsuario
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//        }
//    }
//}

//using SistemaBiblioteca.Dados;
//using UsuariosBiblioteca.Estudantes;

//namespace InterfaceUsuario
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Estudante>? estudantes = new List<Estudante>();

//            var ManipularEstudante = new ManipularJsonEstudante();
//            estudantes = ManipularEstudante.LerJsonEstudantes();


//            //Agora você tem uma lista de objetos para utilizar
//            foreach (var estudante in estudantes)
//            {
//                Console.WriteLine($"Código de Cadastro: {estudante.Matricula}");
//                Console.WriteLine($"Nome: {estudante.Nome}");
//                Console.WriteLine($"E - mail: {Estudante.Email}");
//                Console.WriteLine($"Proxima alteração de senha: {Estudante.ProximaAlteracaoDeSenha}");

//                Console.WriteLine();
//            }
//        }
//    }
//}
