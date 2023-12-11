using eCommerce.Console.Database;
using eCommerce.Console.Screens.ClientScreen;
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
            }
        }
    }
}
