using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Models
{
    public class ProdutosPedidos
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public Pedido Pedido { get; set; } = null!;
        public Produto Produto { get; set; } = null!;
    }
}
