using eCommerce.Console.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public ETipoPagamento TipoPagamento { get; set; }
        public Cliente? Cliente { get; set; }
        public ICollection<Produto>? Produtos { get; set; }
        public ICollection<ProdutosPedidos>? ProdutosPedidos { get; set; }
    }
}
