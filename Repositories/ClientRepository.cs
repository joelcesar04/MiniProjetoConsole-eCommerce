using eCommerce.Console.Database;
using eCommerce.Console.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Repositories
{
    public class ClientRepository : IRepository<Cliente>
    {
        private readonly eCommerceContext _db;
        public ClientRepository(eCommerceContext db)
        {
            _db = db;
        }

        public IEnumerable<Cliente> Get()
        {
            return _db.Clientes
                .Include(cont => cont.Contato)
                .Include(end => end.Endereco)
                .ToList();
        }

        public Cliente Get(int id)
        {
            return _db.Clientes
                .Include(cont => cont.Contato)
                .Include(end => end.Endereco)
                .FirstOrDefault(a => a.ClienteId == id)!;
        }

        public void Create(Cliente cliente)
        {
            _db.Clientes.Add(cliente);
            _db.SaveChanges();
        }
        public void Update(Cliente cliente)
        {
            _db.Clientes.Update(cliente);
            _db.SaveChanges();
        }

        public void Delete(Cliente cliente)
        {
            _db.Clientes.Remove(cliente);
            _db.SaveChanges();
        }
    }
}
