﻿using eCommerce.Console.Database;
using eCommerce.Console.Screens.CategoryScreen;
using eCommerce.Console.Screens.ClientScreen;
using eCommerce.Console.Screens.ProductScreen;
using eCommerce.Console.Screens.RequestScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens
{
    public static class Menus
    {
        public static void ClientMenu()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DO CLIENTE");
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Escolha a opção que deseja?");

            System.Console.WriteLine("1 - Listar Clientes");
            System.Console.WriteLine("2 - Listar Cliente (1)");
            System.Console.WriteLine("3 - Incluir Cliente");
            System.Console.WriteLine("4 - Atualizar Cliente");
            System.Console.WriteLine("5 - Deletar Cliente");
            System.Console.WriteLine("0 - Voltar");

            System.Console.WriteLine();

            System.Console.Write("R: ");
            var response = int.Parse(System.Console.ReadLine()!);

            switch (response)
            {
                case 1:
                    ListClient.Load();
                    break;
                case 2:
                    ListClient.LoadId();
                    break;
                case 3:
                    CreateClient.LoadCreate();
                    break;
                case 4:
                    UpdateClient.LoadUpdate();
                    break;
                case 5:
                    DeleteClient.LoadDelete();
                    break;

                case 0:
                    Program.Main();
                    break;
            }
        }

        public static void CategoryMenu()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DAS CATEGORIAS");
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Escolha a opção que deseja?");

            System.Console.WriteLine("1 - Listar Categorias C/ Produtos");
            System.Console.WriteLine("2 - Listar Categoria (1)");
            System.Console.WriteLine("3 - Incluir Categoria");
            System.Console.WriteLine("4 - Atualizar Categoria");
            System.Console.WriteLine("5 - Deletar Categoria");
            System.Console.WriteLine("0 - Voltar");

            System.Console.WriteLine();

            System.Console.Write("R: ");
            var response = int.Parse(System.Console.ReadLine()!);

            switch (response)
            {
                case 1:
                    ListCategory.Load();
                    break;
                case 2:
                    ListCategory.LoadId();
                    break;
                case 3:
                    CreateCategory.LoadCreate();
                    break;
                case 4:
                    UpdateCategory.LoadUpdate();
                    break;
                case 5:
                    DeleteCategory.LoadDelete();
                    break;

                case 0:
                    Program.Main();
                    break;
            }

        }

        public static void ProductMenu()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PRODUTOS");
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Escolha a opção que deseja?");

            System.Console.WriteLine("1 - Listar Produtos");
            System.Console.WriteLine("2 - Listar Produto (1)");
            System.Console.WriteLine("3 - Incluir Produto");
            System.Console.WriteLine("4 - Atualizar Produto");
            System.Console.WriteLine("5 - Deletar Produto");
            System.Console.WriteLine("0 - Voltar");

            System.Console.WriteLine();

            System.Console.Write("R: ");
            var response = int.Parse(System.Console.ReadLine()!);

            switch (response)
            {
                case 1:
                    ListProduct.Load();
                    break;
                case 2:
                    ListProduct.LoadId();
                    break;
                case 3:
                    CreateProduct.LoadCreate();
                    break;
                case 4:
                    UpdateProduct.LoadUpdate();
                    break;
                case 5:
                    DeleteProduct.LoadDelete();
                    break;

                case 0:
                    Program.Main();
                    break;
            }

        }

        public static void RequestMenu()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PEDIDOS");
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Escolha a opção que deseja?");

            System.Console.WriteLine("1 - Listar Pedidos");
            System.Console.WriteLine("2 - Listar Pedido (1)");
            System.Console.WriteLine("3 - Cadastrar Pedido");
            System.Console.WriteLine("4 - Cancelar Pedido");
            System.Console.WriteLine("0 - Voltar");

            System.Console.WriteLine();

            System.Console.Write("R: ");
            var response = int.Parse(System.Console.ReadLine()!);

            switch (response)
            {
                case 1:
                    ListRequest.Load();
                    break;
                case 2:
                    ListRequest.LoadId();
                    break;
                case 3:
                    CreateRequest.LoadCreate();
                    break;
                case 4:
                    DeleteRequest.LoadDelete();
                    break;

                case 0:
                    Program.Main();
                    break;

            }
        }
    }
}
