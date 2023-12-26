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
    public static class UpdateCategory
    {
        public static void LoadUpdate()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DAS CATEGORIAS");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();
            System.Console.Write("Qual o código da categoria que deseja atualizar? ");
            var codigo = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            System.Console.WriteLine("INFORMAÇÕES:");
            System.Console.Write(" Nome do Categoria: ");
            var nameCategory = System.Console.ReadLine();
            System.Console.Write(" Descrição da Categoria: ");
            var description = System.Console.ReadLine();

            var category = new Categoria()
            {
                CategoriaId = codigo,
                Nome = nameCategory!,
                Descricao = description
            };

            System.Console.WriteLine();
            Update(category);

            System.Console.WriteLine();
            System.Console.WriteLine("Retornando ao menu...");
            Thread.Sleep(2000);
            Menus.CategoryMenu();

        }

        private static void Update(Categoria category)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new CategoryRepository(context);
                try
                {
                    repository.Update(category);
                    System.Console.WriteLine($"O cliente ({category.CategoriaId}) foi atualizado com sucesso!");
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível atualizar o categoria!");
                    System.Console.WriteLine(ex.Message);
                    System.Console.ReadKey();
                }

            }
        }
    }
}