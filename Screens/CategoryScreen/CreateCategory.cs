using eCommerce.Console.Database;
using eCommerce.Console.Models;
using eCommerce.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.CategoryScreen
{
    public static class CreateCategory
    {
        public static void LoadCreate()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DAS CATEGORIAS");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            System.Console.WriteLine("INFORMAÇÕES:");
            System.Console.Write(" Nome da Categoria: ");
            var nameCategory = System.Console.ReadLine();
            System.Console.Write(" Descrição da Categoria: ");
            var description = System.Console.ReadLine();

            var category = new Categoria()
            {
                Nome = nameCategory!,
                Descricao = description
            };

            System.Console.WriteLine();
            Create(category);

            System.Console.WriteLine("Retornando ao menu...");
            Thread.Sleep(2000);
            Menus.CategoryMenu();

        }

        private static void Create(Categoria category)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new CategoryRepository(context);
                try
                {
                    repository.Create(category);
                    System.Console.WriteLine("Categoria Cadastrada!");
                    System.Console.WriteLine();
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível cadastrar a categoria!");
                    System.Console.WriteLine(ex.Message);
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
