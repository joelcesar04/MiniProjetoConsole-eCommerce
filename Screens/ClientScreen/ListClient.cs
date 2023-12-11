using eCommerce.Console.Database;
using eCommerce.Console.Models;
using eCommerce.Console.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.ClientScreen
{
    public class ListClient
    {
        public static void Load()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DO CLIENTE");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            List();

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.ClientMenu();

        }

        public static void LoadId()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DO CLIENTE");
            System.Console.WriteLine("-----------------");
            System.Console.Write("Digite o código do cliente que deseja buscar: ");
            var codigo = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            ListId(codigo);

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.ClientMenu();

        }

        private static void List()
        {
            using (var context = new eCommerceContext())
            {
                var repository = new ClientRepository(context);
                var clients = repository.Get();

                if (!clients.Any())
                {
                    System.Console.WriteLine("Nenhum cliente cadastrado. Por gentileza, efetue o cadastro.");
                    System.Console.ReadKey();

                    Menus.ClientMenu();
                }
                else
                {
                    foreach (var client in clients)
                    {
                        System.Console.WriteLine($"CÓD. CLIENTE: {client.ClienteId} - NOME: {client.Nome}");
                        System.Console.WriteLine($" - CONTATO: {client.Contato!.DDD} {client.Contato!.Celular}");
                        System.Console.WriteLine($" - ENDEREÇO: {client.Endereco!.NomeEndereco}, {client.Endereco!.Numero} - {client.Endereco!.CEP}");
                        System.Console.WriteLine();
                    }
                }
            }
        }

        private static void ListId(int codigo)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new ClientRepository(context);
                var client = repository.Get(codigo);

                if (client == null)
                {
                    System.Console.WriteLine($"Nenhum cliente encontrado com o código ({codigo}). Por gentileza, tente novamente.");
                    System.Console.ReadKey();

                    Menus.ClientMenu();
                }
                else
                {
                    System.Console.WriteLine($"CÓD. CLIENTE: {client.ClienteId} - NOME: {client.Nome}");
                    System.Console.WriteLine($" - CONTATO: {client.Contato!.DDD} {client.Contato!.Celular}");
                    System.Console.WriteLine($" - ENDEREÇO: {client.Endereco!.NomeEndereco}, {client.Endereco!.Numero} - {client.Endereco!.CEP}");
                    System.Console.WriteLine();
                }
            }
        }

    }
}
