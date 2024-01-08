using eCommerce.Console.Database;
using eCommerce.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Repositories
{
    public class ProductRepository : IRepository<Produto>
    {
        private static eCommerceContext _db;
        public ProductRepository(eCommerceContext db)
        {
            _db = db;
        }

        public IEnumerable<Produto> Get()
        {
            return _db.Produtos.ToList();
        }

        public Produto Get(int id)
        {
            return _db.Produtos.FirstOrDefault(x => x.ProdutoId == id)!;
        }

        public void Create(Produto model)
        {
            _db.Produtos.Add(model);
            _db.SaveChanges();
        }
        public void Update(Produto model)
        {
            _db.Produtos.Update(model);
            _db.SaveChanges();
        }

        public void Delete(Produto model)
        {
            _db.Produtos.Remove(model);
            _db.SaveChanges();
        }

    }
}
