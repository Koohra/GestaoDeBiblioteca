﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Dados
{
    internal class ManipularArquivosJson
    {
   
        public string nomeArquivo(string nomeArquivo)
        {
            string arquivoJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dados", nomeArquivo);
            return arquivoJson; 
        }
   
        public void crudEstudante()
        {
            string arquivoJson = nomeArquivo("ListaDeEstudantes.json");

            var json = File.ReadAllText(arquivoJson);
            try
            {
                var jObject = JObject.Parse(json);
                if (jObject != null)
                {
                    // Mudar para Especifico ***********
                    //WriteLine("ID :" + jObject["id"].ToString());
                    //WriteLine("Nome :" + jObject["nome"].ToString());
                    //var endereco = jObject["endereco"];
                    //WriteLine("Rua :" + endereco["rua"].ToString());
                    //WriteLine("Cidade :" + endereco["cidade"].ToString());
                    //WriteLine("Cep :" + endereco["cep"]);
                  
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    }

 /*
    public class JsonCrud
    {
        public void DetalhesdoUsuario(string Caminho)
        {
            var json = File.ReadAllText(Caminho);
            try
            {
                var jObject = JObject.Parse(json);
                if (jObject != null)
                {
                    WriteLine("ID :" + jObject["id"].ToString());
                    WriteLine("Nome :" + jObject["nome"].ToString());
                    var endereco = jObject["endereco"];
                    WriteLine("Rua :" + endereco["rua"].ToString());
                    WriteLine("Cidade :" + endereco["cidade"].ToString());
                    WriteLine("Cep :" + endereco["cep"]);
                    JArray arrayExperiencias = (JArray)jObject["experiencias"];
                    if (arrayExperiencias != null)
                    {
                        WriteLine("Empresas");
                        foreach (var item in arrayExperiencias)
                        {
                            WriteLine("\tId :" + item["empresaid"]);
                            WriteLine("\tEmpresa :" + item["empresanome"].ToString());
                        }
                    }
                    WriteLine("Telefone :" + jObject["telefone"].ToString());
                    WriteLine("Cargo :" + jObject["cargo"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //incluir empresa
        public void AdicionarEmpresa(string Caminho)
        {
            WriteLine("Informe o Id da empresa : ");
            var empresaId = Console.ReadLine();
            WriteLine("\nQual o nome da Empresa : ");
            var nomeEmpresa = Console.ReadLine();
            var novaEmpresaMembro = "{ 'empresaid': " + empresaId + ", 'empresanome': '" + nomeEmpresa + "'}";
            try
            {
                var json = File.ReadAllText(Caminho);
                var jsonObj = JObject.Parse(json);
                var arrayExperiencias = jsonObj.GetValue("experiencias") as JArray;
                var novaEmpresa = JObject.Parse(novaEmpresaMembro);
                arrayExperiencias.Add(novaEmpresa);
                jsonObj["experiencias"] = arrayExperiencias;
                string novoJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(Caminho, novoJsonResult);
            }
            catch (Exception ex)
            {
                WriteLine("Erro ao adicionar : " + ex.Message.ToString());
            }
        }
        //deletar empresa
        public void DeletarEmpresa(string Caminho)
        {
            var json = File.ReadAllText(Caminho);
            try
            {
                var jObject = JObject.Parse(json);
                JArray arrayExperiencias = (JArray)jObject["experiencias"];
                Write("Informe o ID da Empresa a deletar : ");
                var empresaId = Convert.ToInt32(Console.ReadLine());
                if (empresaId > 0)
                {
                    var nomeEmpresa = string.Empty;
                    var empresaADeletar = arrayExperiencias.FirstOrDefault(obj => obj["empresaid"].Value<int>() == empresaId);
                    arrayExperiencias.Remove(empresaADeletar);
                    string saida = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(Caminho, saida);
                }
                else
                {
                    Write("O ID da empresa é inválido, tente novamente!");
                    AtualizarEmpresa(Caminho);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //atualizar empresa
        public void AtualizarEmpresa(string Caminho)
        {
            string json = File.ReadAllText(Caminho);
            try
            {
                var jObject = JObject.Parse(json);
                JArray arrayExperiencias = (JArray)jObject["experiencias"];
                Write("Informe o ID da empresa a atualizar : ");
                var empresaId = Convert.ToInt32(Console.ReadLine());
                if (empresaId > 0)
                {
                    Write("Informe o nome da empresa: ");
                    var nomeEmpresa = Convert.ToString(Console.ReadLine());
                    foreach (var empresa in arrayExperiencias.Where(obj =>
                                       obj["empresaid"].Value<int>() == empresaId))
                    {
                        empresa["empresanome"] = !string.IsNullOrEmpty(nomeEmpresa) ? nomeEmpresa : "";
                    }
                    jObject["experiencias"] = arrayExperiencias;
                    string saida = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(Caminho, saida);
                }
                else
                {
                    Write("O ID da empresa é inválido, tente novamente!");
                    AtualizarEmpresa(Caminho);
                }
            }
            catch (Exception ex)
            {
                WriteLine("Erro de Atualização : " + ex.Message.ToString());
            }
        }
        //fim
    }
}
 */