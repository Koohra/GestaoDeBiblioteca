using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ControleDoAcervo.Reservas;

namespace ControleDoAcervo.Livros
{
    public class LivroService
    {
        public string Caminho { get; private set; }
        public static List<Livro> Livros { get; private set; } = new List<Livro>();

        public LivroService(string? arquivo = "LivrosAcervo.json")
        {
            Caminho = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Livros", arquivo);
            Caminho = Caminho.Replace("InterfaceUsuario\\bin\\Debug\\net8.0", "AcervoLivro");
        }

        private bool VerificaSeLivroJaExiste(Livro livro)
        {
            try
            {
                List<Livro> Livros = DeserializaJSON();
                Livro? livroIgual = Livros.FirstOrDefault(l => l.Titulo == livro.Titulo && l.Autor == livro.Autor && l.Reservas == livro.Reservas);
                if (livroIgual != null)
                    return true;
                return false;
            } catch (Exception ex)
            {
                Console.WriteLine($"Não foi possível verificar se livro já existe: {ex}");
                return false;
            }
        }

        private List<Livro>? DeserializaJSON()
        {
            try
            {
                var json = File.ReadAllText(Caminho);
                JArray livrosJSON = JArray.Parse(json);

                foreach (var livroJSON in livrosJSON)
                {
                    Livro? livro = JsonConvert.DeserializeObject<Livro?>(livroJSON.ToString());
                    if (livro != null)
                        Livros.Add(livro);
                }
                return Livros.DistinctBy(livro => livro.Titulo).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao desserializar o arquivo JSON de Livros: {ex}");
                return null;
            }
        }

        private void SerializaJSON(List<Livro>? livros)
        {
            try
            {
                var json = JsonConvert.SerializeObject(livros, Formatting.Indented);
                File.WriteAllText(Caminho, json);
            } catch(Exception ex)
            {
                Console.WriteLine($"Não foi possível salvar as alterações no JSON: {ex}");
            }
        }

        public void CriarLivro(Livro novoLivro)
        {
            try
            {
                if (VerificaSeLivroJaExiste(novoLivro))
                    Console.WriteLine("Este livro já existe no sistema.");
                else
                {
                    List<Livro> Livros = DeserializaJSON();
                    Livros.Add(novoLivro);
                    SerializaJSON(Livros);
                    Console.WriteLine("Livro criado com sucesso.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível criar um livro: {e}");
            }
        }

        public List<Livro>? LerLivros()
        {
            try
            {
                return DeserializaJSON();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler todos os livros do arquivo JSON: {e}");
                return null;
            }
        }

        public Livro? LerLivroPorID(int id)
        {
            try
            {
                List<Livro> Livros = DeserializaJSON();
                Livro? livro = Livros.FirstOrDefault(livro => livro.Id == id);

                if (livro != null)
                {
                    Console.WriteLine("Livro encontrado:\n");
                    livro.ExibirInformacoes();
                }
                else
                    Console.WriteLine($"Livro com ID {id} não encontrado.");
                return livro;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler o livro com ID {id}: {e}");
                return null;
            }
        }

        public void AlterarLivroPorID(int id, Livro livroAtualizado)
        {
            try
            {
                List<Livro> Livros = DeserializaJSON();
                Livro? livroParaAtualizar = Livros.FirstOrDefault(livro => livro.Id == id);

                if (livroParaAtualizar != null)
                {
                    Livros.Remove(livroParaAtualizar);
                    livroParaAtualizar.Titulo = livroAtualizado.Titulo;
                    livroParaAtualizar.Autor = livroAtualizado.Autor;
                    livroParaAtualizar.AnoPublicacao = livroAtualizado.AnoPublicacao;
                    livroParaAtualizar.AtualizarExemplares();
                    livroParaAtualizar.Reservas = livroAtualizado.Reservas;
                    Livros.Add(livroParaAtualizar);

                    SerializaJSON(Livros);

                    Console.WriteLine($"Livro com ID {id} atualizado com sucesso.");
                    livroParaAtualizar.ExibirInformacoes();
                }
                else
                    Console.WriteLine($"Livro com ID {id} não foi encontrado.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível alterar o livro com ID {id}: {e}");
            }
        }

        public void DeletarLivroPorID(int id)
        {
            try
            {
                List<Livro>? Livros = DeserializaJSON();
                var livroParaDeletar = Livros.FirstOrDefault(livro => livro.Id == id);

                if (livroParaDeletar != null)
                {
                    Livros.Remove(livroParaDeletar);
                    SerializaJSON(Livros);
                    Console.WriteLine($"Livro com ID {id} deletado com sucesso.");
                }
                else
                    Console.WriteLine($"Livro com ID {id} não encontrado.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível deletar o livro com ID {id}: {e}");
            }
        }

        public void DeletarLivroTitulo(string titulo)
        {
            try
            {
                List<Livro>? Livros = DeserializaJSON();

                foreach (var livro in Livros)
                {
                    if (livro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                    {
                        Livros.Remove(livro);
                        SerializaJSON(Livros);
                        Console.WriteLine($"O livro {titulo} foi deletado com sucesso.");
                    }
                    else
                        Console.WriteLine($"O livro {titulo} não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível deletar o livro {titulo}: {e}");
            }
        }

        public void EmprestarLivro(int id, Dictionary<EstadoExemplar, int> exemplarAtualizado)
        {
            try
            {
                List<Livro>? livros = LerLivros();
                Livro? livroParaAtualizar = Livros.FirstOrDefault(livro => livro.Id == id);

                if (livroParaAtualizar != null)
                {
                    livroParaAtualizar.Exemplares = exemplarAtualizado;
                    SerializaJSON(livros);
                    Console.WriteLine($"Livro com ID {id} atualizado com sucesso.");
                    livroParaAtualizar.ExibirInformacoes();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Õcorreu um erro ao emprestar um livro: {ex}");
            }
        }

        public void AtualizarExemplares(int id)
        {
            try
            {
                List<Livro>? livros = LerLivros();
                Livro? livroParaAtualizar = livros.FirstOrDefault(livro => livro.Id == id);

                if (livroParaAtualizar != null)
                {
                    livroParaAtualizar.Exemplares = Livro.ReceberEstadoExemplar();

                    SerializaJSON(Livros);

                    Console.WriteLine($"Livro com ID {id} atualizado com sucesso.");
                    livroParaAtualizar.ExibirInformacoes();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao atualizar os exemplares: {ex}");
            }
        }

        public void ReservarLivro(int id, string matricula)
        {
            try
            {
                List<Livro>? livros = LerLivros();
                Livro? livroParaReservar = livros.FirstOrDefault(livro => livro.Id == id);

                if (livroParaReservar != null)
                {
                    Reserva reserva = livroParaReservar.AdicionarReserva(matricula);
                    reserva.ExibirInformacoes();
                    SerializaJSON(livros);

                    Console.WriteLine($"Livro com ID {id} reservado com sucesso.");
                    livroParaReservar.ExibirInformacoes();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao reservar um livro: {ex}");
            }
        }
    }
}

