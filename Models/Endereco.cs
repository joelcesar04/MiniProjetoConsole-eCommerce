using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public int ClienteId { get; set; }
        public string NomeEndereco { get; set; } = null!;
        public int Numero { get; set; }
        public string Bairro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string CEP { get; set; } = null!;
        public string? Complemento { get; set; }
        public Cliente? Cliente { get; set; }

    }
}
