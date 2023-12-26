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
    public static class ListCategory
    {
        public static void Load()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DAS CATEGORIAS");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            List();

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.CategoryMenu();

        }

        public static void LoadId()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DAS CATEGORIAS");
            System.Console.WriteLine("-----------------");
            System.Console.Write("Digite o código do categoria que deseja buscar: ");
            var codigo = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            ListId(codigo);

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.CategoryMenu();

        }

        private static void List()
        {
            using (var context = new eCommerceContext())
            {
                var repository = new CategoryRepository(context);
                var categories = repository.Get();

                if (!categories.Any())
                {
                    System.Console.WriteLine("Nenhuma categoria cadastrada. Por gentileza, efetue o cadastro.");
                    System.Console.ReadKey();

                    Menus.CategoryMenu();
                }
                else
                {
                    foreach (var category in categories)
                    {
                        System.Console.WriteLine($"CÓD. CATEGORIA: {category.CategoriaId} - NOME: {category.Nome}");
                        foreach (var products in category.Produtos!)
                        {
                            System.Console.WriteLine($" - NOME: {products.Nome} | DESCRIÇÃO: {products.Descricao} | PREÇO: {products.Preco}");
                        }
                        System.Console.WriteLine("-----------------------------");
                    }
                }
            }
        }

        private static void ListId(int codigo)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new CategoryRepository(context);
                var category = repository.Get(codigo);

                if (category == null)
                {
                    System.Console.WriteLine($"Nenhuma categoria encontrado com o código ({codigo}). Por gentileza, tente novamente.");
                    System.Console.ReadKey();

                    Menus.CategoryMenu();
                }
                else
                {
                    System.Console.WriteLine($"CÓD. CATEGORIA: {category.CategoriaId} - NOME: {category.Nome}");
                    foreach (var products in category.Produtos!)
                    {
                        System.Console.WriteLine($" - NOME: {products.Nome} | DESCRIÇÃO: {products.Descricao} | PREÇO: {products.Preco}");
                    }
                    System.Console.WriteLine("-----------------------------");

                }
            }
        }

    }
}
