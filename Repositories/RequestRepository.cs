using eCommerce.Console.Database;
using eCommerce.Console.Models;
using eCommerce.Console.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Repositories
{
    public class RequestRepository : IRepository<Pedido>
    {
        private readonly eCommerceContext _db;

        public RequestRepository(eCommerceContext db)
        {
            _db = db;
        }

        public IEnumerable<Pedido> Get()
        {
            return _db.Pedidos
                .Include(c => c.Cliente)
                .Include(a => a.ProdutosPedidos!)
                .ThenInclude(prod => prod.Produto)
                .ToList();
        }

        public Pedido Get(int id)
        {
            return _db.Pedidos
                .Include(c => c.Cliente)
                .Include(a => a.ProdutosPedidos!)
                .ThenInclude(prod => prod.Produto)
                .FirstOrDefault(x => x.PedidoId == id)!;
        }

        public void Create(Pedido model)
        {
            _db.Pedidos.Add(model);
            _db.SaveChanges();
        }

        public void Update(Pedido model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pedido model)
        {
            _db.Pedidos.Remove(model);
            _db.SaveChanges();
        }
    }
}
