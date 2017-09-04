using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFilme.Models
{
    public class FilmeGeneroViewModel
    {
        public List<Filme> filmes { get; set; }
        public SelectList generos;
        public string filmeGenero { get; set; }
    }
}
