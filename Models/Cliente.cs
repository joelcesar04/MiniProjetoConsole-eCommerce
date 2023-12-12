using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Sexo { get; set; }
        public string RG { get; set; } = null!;
        public string CPF { get; set; } = null!;
        public DateTime DataCadastro { get; set; }
        public Contato Contato { get; set; } = new Contato();
        public Endereco Endereco { get; set; } = new Endereco();
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
