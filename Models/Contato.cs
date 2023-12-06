using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public int ClienteId { get; set; }
        public string DDD { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public Cliente? Cliente { get; set; }
    }
}
