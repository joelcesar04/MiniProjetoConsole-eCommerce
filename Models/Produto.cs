﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public Categoria? Categoria { get; set; }
        public ICollection<ProdutosPedidos>? ProdutosPedidos { get; set; }
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
