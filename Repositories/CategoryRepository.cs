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
    public class CategoryRepository : IRepository<Categoria>
    {
        private readonly eCommerceContext _db;
        public CategoryRepository(eCommerceContext eCommerceContext)
        {
            _db = eCommerceContext;
        }
        public IEnumerable<Categoria> Get()
        {
            return _db.Categorias
                .Include(prod => prod.Produtos)
                .ToList();
        }

        public Categoria Get(int id)
        {
            return _db.Categorias
                .Include(prod => prod.Produtos)
                .FirstOrDefault(x => x.CategoriaId == id)!;
        }

        public void Create(Categoria model)
        {
            _db.Categorias.Add(model);
            _db.SaveChanges();
        }

        public void Update(Categoria model)
        {
            _db.Categorias.Update(model);
            _db.SaveChanges();
        }

        public void Delete(Categoria model)
        {
            _db.Categorias.Remove(model);
            _db.SaveChanges();
        }
    }
}
