using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstMVC.Models.Enuns;

namespace EstMVC.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string? Nome { get; set; }

        public int Qtd { get; set; }

        public CategoriaEnum Categoria{ get; set; }
    }
}