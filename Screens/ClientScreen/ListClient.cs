using eCommerce.Console.Database;
using eCommerce.Console.Models;
using eCommerce.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.UserScreen
{
    public class ListClient
    {
        private static ClientRepository? _clientRepository;

        public ListClient(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public static void Load()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DO USUÁRIO");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            List();

            Menus.ClientMenu();
        }
        public static void LoadId()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DO USUÁRIO");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();
            System.Console.Write("Qual o código do cliente que deseja exibir?");
            var cod = int.Parse(System.Console.ReadLine()!);

            ListId(cod);

            Menus.ClientMenu();

        }
        private static void List()
        {
            var clients = _clientRepository!.Get();

            foreach (var client in clients)
            {
                System.Console.WriteLine($"CÓD: {client.ClienteId} - NOME: {client.Nome}");
                System.Console.WriteLine($" - CONTATO: ({client.Contato!.DDD}) {client.Contato.Celular}");
                System.Console.WriteLine($" - ENDEREÇO: {client.Endereco!.NomeEndereco}, {client.Endereco!.Numero} - {client.Endereco!.CEP}");
            }
        }
        private static void ListId(int id)
        {
            var client = _clientRepository!.Get(id);

            System.Console.WriteLine($"CÓD: {client.ClienteId} - NOME: {client.Nome}");
            System.Console.WriteLine($" - CONTATO: ({client.Contato!.DDD}) {client.Contato.Celular}");
            System.Console.WriteLine($" - ENDEREÇO: {client.Endereco!.NomeEndereco}, {client.Endereco!.Numero} - {client.Endereco!.CEP}");
        }
    }
}
