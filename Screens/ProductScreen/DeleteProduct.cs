using eCommerce.Console.Database;
using eCommerce.Console.Models;
using eCommerce.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.ProductScreen
{
    public static class DeleteProduct
    {
        public static void LoadDelete()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PRODUTOS");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            System.Console.Write("Qual o código do produto que deseja deletar? ");
            var codigo = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            Delete(codigo);

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.ProductMenu();
        }

        private static void Delete(int codigo)
        {
            using (var eCommerceContext = new eCommerceContext())
            {
                var repository = new ProductRepository(eCommerceContext);
                var product = repository.Get(codigo);

                try
                {
                    repository.Delete(product);
                    System.Console.WriteLine($"O cliente ({product.ProdutoId}) foi deletado com sucesso!");
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível deletar o produto!");
                    System.Console.WriteLine(ex.Message);
                    System.Console.ReadKey();
                }
            }
        }
    }
}
