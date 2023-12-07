using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public int ProdutoId { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public ICollection<Produto>? Produtos { get; set; }
    }
}
