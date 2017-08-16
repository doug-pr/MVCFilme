﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFilme.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Lancamento { get; set; }
        public string Genero { get; set; }
        public decimal Preco { get; set; }
    }
}
