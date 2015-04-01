using CafeA4.Entidades;
using CafeA4.Persistencia;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace CafeA4.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            VisualizadorDeMudancas();
        }

        static void VisualizadorDeMudancas()
        {
            using (var contexto = new CafeA4DbContext())
            {
                Console.WriteLine("Encontra o Leitor 1");
                var leitor = contexto.Leitores.Find(1);

                Console.Write("O contexto está acompanhando as mudanças em {0} entidade.", contexto.ChangeTracker.Entries().Count());

                ApresentaEstadoEntidade(contexto.ChangeTracker);

                Console.WriteLine("Encontra clube de leitura");

                var clube = contexto.ClubesDeLeitura.Find(1);

                Console.Write("O contexto está acompanhando as mudanças em {0} entidades.", contexto.ChangeTracker.Entries().Count());
                Console.WriteLine("");
                Console.WriteLine("Editando o leitor");

                leitor.Email = "email@email.com";
                ApresentaEstadoEntidade(contexto.ChangeTracker);

                var novoLivro = new Livro
                {
                    Titulo = "O segredo",
                    Sinopse = "Um livro totalmente dispensável",
                    Autor = new Autor
                    {
                        Nome = "Rhonda Byrne"
                    }
                };

                Console.WriteLine("Adicionando um novo livro");

                contexto.Livros.Add(novoLivro);

                Console.WriteLine("");
                Console.Write("O contexto está acompanhando as mudanças em {0} entidades.", contexto.ChangeTracker.Entries().Count());

                ApresentaEstadoEntidade(contexto.ChangeTracker);

                Console.WriteLine("Removendo um livro.");
                Console.WriteLine("");

                contexto.Livros.Remove(novoLivro);
                ApresentaEstadoEntidade(contexto.ChangeTracker);

                contexto.SaveChanges();

                Console.ReadKey();
            }
        }

        static void ApresentaEstadoEntidade(DbChangeTracker traker)
        {
            Console.WriteLine("");

            var entries = traker.Entries();
            foreach (var entry in entries)
            {
                Console.WriteLine("Nome da entidade: {0}", entry.Entity.GetType().FullName);
                Console.WriteLine("Estado: {0}", entry.State);
            }
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------");
        }
    }
}