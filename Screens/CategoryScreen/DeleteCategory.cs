using eCommerce.Console.Database;
using eCommerce.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.CategoryScreen
{
    public static class DeleteCategory
    {
        public static void LoadDelete()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DAS CATEGORIAS");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            System.Console.Write("Qual o código da categoria que deseja deletar? ");
            var codigo = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            Delete(codigo);

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.CategoryMenu();
        }

        private static void Delete(int codigo)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new CategoryRepository(context);
                var category = repository.Get(codigo);

                try
                {
                    repository.Delete(category);
                    System.Console.WriteLine($"A categoria ({category.CategoriaId}) foi deletado com sucesso!");
                    Thread.Sleep(2000);

                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível deletar o categoria!");
                    System.Console.WriteLine(ex.Message);
                    System.Console.ReadKey();

                }
            }
        }
    }
}

