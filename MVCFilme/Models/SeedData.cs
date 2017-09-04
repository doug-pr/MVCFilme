using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFilme.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCFilmeContext(
                serviceProvider.GetRequiredService<DbContextOptions<MVCFilmeContext>>()))
            {
                if (context.Filme.Any())
                {
                    return;
                }
                context.Filme.AddRange(
                    new Filme
                    {
                        Titulo = "A Bela e a Fera",
                        Classificacao = "L",
                        Lancamento = DateTime.Parse("2017-3-16"),
                        Genero = "Fantasia/Romance",
                        Preco = 7.99M
                    },
                     new Filme
                     {
                         Titulo = "Caça-Fantasmas",
                         Classificacao = "12",
                         Lancamento = DateTime.Parse("1984-3-13"),
                         Genero = "Comedia",
                         Preco = 8.99M
                     },
                     new Filme
                     {
                         Titulo = "Kong - A ilha da Caveira",
                         Classificacao = "18",
                         Lancamento = DateTime.Parse("2017-3-09"),
                         Genero = "Ficção",
                         Preco = 9.99M

                     },
                     new Filme
                     {
                         Titulo = "Rio Bravo",
                         Classificacao = "16",
                         Lancamento = DateTime.Parse("1959-4-15"),
                         Genero = "Western",
                         Preco = 3.99M
                     }
                 );
                context.SaveChanges();
            }
        }
    }
}
