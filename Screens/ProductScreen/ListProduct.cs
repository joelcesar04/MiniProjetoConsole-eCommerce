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
    public static class ListProduct
    {
        public static void Load()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PRODUTOS");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            List();

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.ProductMenu();

        }
        public static void LoadId()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PRODUTOS");
            System.Console.WriteLine("-----------------");
            System.Console.Write("Digite o código do produto que deseja buscar: ");
            var codigo = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            ListId(codigo);

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.ProductMenu();
        }

        private static void List()
        {
            using (var eCommerceContext = new eCommerceContext())
            {
                var repository = new ProductRepository(eCommerceContext);
                var products = repository.Get();

                if (!products.Any())
                {
                    System.Console.WriteLine("Nenhum produto cadastrado. Por gentileza, efetue o cadastro.");
                    System.Console.ReadKey();

                    Menus.ProductMenu();
                }
                else
                {
                    foreach (var product in products)
                    {
                        System.Console.WriteLine($"CÓD. PRODUTO: {product.ProdutoId} - NOME: {product.Nome}");
                        System.Console.WriteLine($" - DESCRIÇÃO: {product.Descricao}");
                        System.Console.WriteLine($" - PREÇO: {product.Preco}");
                        System.Console.WriteLine();
                    }
                }
            }
        }
        private static void ListId(int codigo)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new ProductRepository(context);
                var product = repository.Get(codigo);

                if (product == null)
                {
                    System.Console.WriteLine($"Nenhum produto encontrado com o código ({codigo}). Por gentileza, tente novamente.");
                    System.Console.ReadKey();

                    Menus.ProductMenu();
                }
                else
                {
                    System.Console.WriteLine($"CÓD. PRODUTO: {product.ProdutoId} - NOME: {product.Nome}");
                    System.Console.WriteLine($" - DESCRIÇÃO: {product.Descricao}");
                    System.Console.WriteLine($" - PREÇO: {product.Preco}");
                    System.Console.WriteLine();
                }
            }
        }

    }
}
