using eCommerce.Console.Database;
using eCommerce.Console.Models;
using eCommerce.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.ProductScreen
{
    public static class CreateProduct
    {
        public static void LoadCreate()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PRODUTOS");
            System.Console.WriteLine("-----------------");
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
            System.Console.Write(" Qual o código da categoria que deseja vincular o produto? ");
            var categoryCode = int.Parse(System.Console.ReadLine()!);

            var product = new Produto()
            {
                CategoriaId = categoryCode,
                Nome = nameProduct!,
                Descricao = description,
                Preco = price
            };

            System.Console.WriteLine();
            Create(product);

            System.Console.WriteLine();
            System.Console.WriteLine("Retornando ao menu...");
            Thread.Sleep(2000);
            Menus.ProductMenu();

        }

        private static void Create(Produto product)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new ProductRepository(context);
                try
                {
                    repository.Create(product);
                    System.Console.WriteLine("Produto Cadastrado!");
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível cadastrar o produto!");
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.InnerException!.Message);
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
