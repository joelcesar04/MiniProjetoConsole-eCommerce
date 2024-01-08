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
    public static class UpdateProduct
    {
        public static void LoadUpdate()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PRODUTOS");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();
            System.Console.Write("Qual o código do produto que deseja atualizar? ");
            var productCode = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            System.Console.WriteLine("INFORMAÇÕES:");
            System.Console.Write(" Nome do Produto: ");
            var nameProduct = System.Console.ReadLine();
            System.Console.Write(" Descrição do Produto: ");
            var description = System.Console.ReadLine();
            System.Console.Write(" Preço do Produto: ");
            var price = decimal.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();
            System.Console.WriteLine("CATEGORIA:");
            System.Console.Write(" Qual o código da categoria que deseja atualizar? ");
            var categoryCode = int.Parse(System.Console.ReadLine()!);

            var product = new Produto()
            {
                ProdutoId = productCode,
                CategoriaId = categoryCode,
                Nome = nameProduct!,
                Descricao = description,
                Preco = price
            };

            System.Console.WriteLine();
            Update(product);

            System.Console.WriteLine();
            System.Console.WriteLine("Retornando ao menu...");
            Thread.Sleep(2000);
            Menus.ProductMenu();
        }

        private static void Update(Produto product)
        {
            using (var eCommerceContext = new eCommerceContext())
            {
                var repository = new ProductRepository(eCommerceContext);
                try
                {
                    repository.Update(product);
                    System.Console.WriteLine($"O produto ({product.ProdutoId}) foi atualizado com sucesso!");
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível atualizar o produto!");
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.InnerException.Message);
                    System.Console.ReadKey();
                }
            }
        }
    }
}
