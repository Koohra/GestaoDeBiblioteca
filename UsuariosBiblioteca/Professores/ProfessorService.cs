﻿using ControleDoAcervo.Livros;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UsuariosBiblioteca.Professores
{
    public class ProfessorService
    {
        public string? Caminho { get; set; }



        public ProfessorService(string arquivoJson = "ListaDeProfessores.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Professores", arquivoJson);
            Caminho = Caminho.Replace("InterfaceUsuario\\bin\\Debug\\net8.0\\", "UsuariosBiblioteca\\");
        }

        public List<Professor>? LerJsonProfessores()
        {
            try
            {
                if (File.Exists(Caminho))
                {
                    var conteudoJson = File.ReadAllText(Caminho);
                    List<Professor>? professores = JsonConvert.DeserializeObject<List<Professor>>(conteudoJson);
                    return professores;
                }

                else
                {
                    Console.WriteLine("O arquivo json não foi encontrado");
                    return new List<Professor>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao ler o json de Professores: {e}");
                return new List<Professor>();
            }


        }
        public void AlterarSenha(string codigoCadastro, string novaSenha)
        {
            try
            {
                List<Professor>? professores = LerJsonProfessores();
                Professor? professorIgual = professores.FirstOrDefault(p => p.CodigoCadastro == codigoCadastro);
                if (professorIgual != null)
                {
                    DateTime proximoMes = DateTime.Now.AddMonths(1);

                    // Realiza as alterações nos campos desejados
                    professorIgual.Senha = novaSenha;
                    professorIgual.ProximaAlteracaoDeSenha = proximoMes.ToString("dd/MM/yyyy");

                    SalvarJsonProfessores(professores);
                    Console.WriteLine("Senha alterada com sucesso para o professor com código: " + codigoCadastro);
                }
                else
                {
                    Console.WriteLine("Professor não encontrado com o código de cadastro fornecido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao tentar alterar a senha: " + ex.Message);
            }
        }

        public void SomarLivrosEmprestados(string codigoCadastro)
        {
            try
            {
                List<Professor>? professores = LerJsonProfessores();
                Professor? professorIgual = professores.FirstOrDefault(p => p.CodigoCadastro == codigoCadastro);
                if (professorIgual != null)
                {
                    // Realiza as alterações nos campos desejados
                    professorIgual.QuantidadeDeLivrosEmprestados = professorIgual.QuantidadeDeLivrosEmprestados + 1;

                    SalvarJsonProfessores(professores);
                    Console.WriteLine($"O professor {professorIgual.Nome} está com" +
                        $" {professorIgual.QuantidadeDeLivrosEmprestados} livros emprestados.");
                }
                else
                {
                    Console.WriteLine("Professor não encontrado com o código de cadastro fornecido.");
                }
            }
            catch (Exception ex2)
            {
                Console.WriteLine("Ocorreu um erro ao tentar alterar a quantidade de livros emprestados" + ex2.Message);
            }
        }

        public void DiminuirLivrosEmprestados(string codigoCadastro)
        {
            try
            {
                List<Professor>? professores = LerJsonProfessores();
                Professor? professorIgual = professores.FirstOrDefault(p => p.CodigoCadastro == codigoCadastro);
                if (professorIgual != null)
                {
                    // Realiza as alterações nos campos desejados
                    professorIgual.QuantidadeDeLivrosEmprestados = professorIgual.QuantidadeDeLivrosEmprestados - 1;

                    SalvarJsonProfessores(professores);
                    Console.WriteLine($"O professor {professorIgual.Nome} está com" +
                       $" {professorIgual.QuantidadeDeLivrosEmprestados} livros emprestados.");
                }
                else
                {
                    Console.WriteLine("Professor não encontrado com o código de cadastro fornecido.");
                }
            }
            catch (Exception ex2)
            {
                Console.WriteLine("Ocorreu um erro ao tentar alterar a quantidade de livros emprestados" + ex2.Message);
            }
        }

        public void SalvarJsonProfessores(List<Professor> professores)
        {

            try
            {
                if (File.Exists(Caminho)) // conferir se vai dar erro
                {
                    // Serializa a lista de professores de volta para o formato JSON
                    string json = JsonConvert.SerializeObject(professores, Formatting.Indented);

                    // Escreve o JSON de volta no arquivo
                    File.WriteAllText(Caminho, json);

                    Console.WriteLine("Alterações salvas com sucesso no arquivo JSON.");
                }
                else
                {
                    Console.WriteLine("Não foi encontrado nenhum arquivo JSON para ser atualizado.");
                }
            }
            catch (Exception ex3)
            {
                Console.WriteLine("Ocorreu um erro ao tentar salvar as alterações no arquivo JSON: " + ex3.Message);
            }
        }

        public void AlterarProfessorPorCodigo(string CodigoCadastro, string nome, string email, string senha)
        {
            try
            {
                List<Professor>? professores = LerJsonProfessores();
                Professor? professorParaAtualizar = professores.FirstOrDefault(professor => professor.CodigoCadastro == CodigoCadastro);

                if (professorParaAtualizar != null)
                {
                    professorParaAtualizar.Nome = nome;
                    professorParaAtualizar.Email = email;
                    professorParaAtualizar.Senha = senha;
                    DateTime proximoMes = DateTime.Now.AddMonths(1);
                    professorParaAtualizar.ProximaAlteracaoDeSenha = proximoMes.ToString("dd/MM/yyyy");

                    SalvarJsonProfessores(professores);

                    Console.WriteLine($"Professor com código {CodigoCadastro} atualizado com sucesso.");
                    professorParaAtualizar.ExibirInformacoes();
                }
                else
                {
                    Console.WriteLine($"Professor com código {CodigoCadastro} não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível alterar o professor com código {CodigoCadastro}: {e}");
            }
        }
    }
}
