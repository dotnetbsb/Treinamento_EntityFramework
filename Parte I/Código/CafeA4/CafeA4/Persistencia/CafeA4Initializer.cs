using CafeA4.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace CafeA4.Persistencia
{
    public class CafeA4Initializer : DropCreateDatabaseAlways<CafeA4DbContext>
    {
        protected override void Seed(CafeA4DbContext context)
        {
            var isaacAsimov = new Autor
            {
                Nome = "Isaac Asimov"
            };

            var iRobot = new Livro
            {
                Titulo = "I, robot",
                Sinopse = @"Here are stories of robots gone mad, of mind-read robots, and robots with a sense of humor. Of robot politicians, and robots who secretly run the world--all told with the dramatic blend of science fact & science fiction that became Asmiov's trademark.",
                Autor = isaacAsimov
            };

            var theRobotsOfDawn = new Livro
            {
                Titulo = "The Robots of Dawn",
                Sinopse = @"A millennium into the future two advances have altered the course of human history: the colonization of the Galaxy and the creation of the positronic brain. Isaac Asimov's Robot novels chronicle the unlikely partnership between a New York City detective and a humanoid robot who must learn to work together.",
                Autor = isaacAsimov
            };

            var theCavesOfSteel = new Livro
            {
                Titulo = "The Caves of Steel",
                Sinopse = @"A millennium into the future two advancements have altered the course of human history:  the colonization of the galaxy and the creation of the positronic brain.  Isaac Asimov's Robot novels chronicle the unlikely partnership between a New York City detective and a humanoid robot who must learn to work together.  Like most people left behind on an over-populated Earth, New York City police detective Elijah Baley had little love for either the arrogant Spacers or their robotic companions.  But when a prominent Spacer is murdered under mysterious circumstances, Baley is ordered to the Outer Worlds to help track down the killer.  The relationship between Life and his Spacer superiors, who distrusted all Earthmen, was strained from the start.  Then he learned that they had assigned him a partner:  R. Daneel Olivaw.  Worst of all was that the 'R' stood for robot--and his positronic partner was made in the image and likeness of the murder victim!",
                Autor = isaacAsimov
            };

            var clubeAzul = new ClubeDeLeitura
            {
                Nome = "Clube Azul",
                Descricao = "Somente livros de capa azul",
                LivroAtual = theCavesOfSteel,
                HistoricoDeLeitura = new List<HistoricoDeLeitura>
                {
                    new HistoricoDeLeitura
                    {
                        Livro = iRobot,
                        Inicio = new DateTime(2015, 01, 03),
                        Fim = new DateTime(2015, 02, 03)
                    }
                }
            };

            var leitor = new Leitor
            {
                Nome = "Matheus Silva",
                Email = "matheus.silva@email.com",
                ClubesDeLeitura = new List<ClubeDeLeitura> { clubeAzul },
                Estante = new List<LivroEstante>
                {
                    new LivroEstante
                    {
                        Livro = iRobot,
                        Status = LivroEstanteStatus.Lido
                    },

                    new LivroEstante
                    {
                        Livro = theRobotsOfDawn,
                        Status = LivroEstanteStatus.PretendoLer
                    },

                    new LivroEstante
                    {
                        Livro = theCavesOfSteel,
                        Status = LivroEstanteStatus.Lendo
                    }
                }
            };

            context.Autores.Add(isaacAsimov);
            context.Livros.Add(iRobot);
            context.Livros.Add(theRobotsOfDawn);
            context.Livros.Add(theCavesOfSteel);
            context.ClubesDeLeitura.Add(clubeAzul);
            context.Leitores.Add(leitor);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException)
            {
            }
            catch (DbEntityValidationException)
            {
            }

            base.Seed(context);
        }
    }
}
