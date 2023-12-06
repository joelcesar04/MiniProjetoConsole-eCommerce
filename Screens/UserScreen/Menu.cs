using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.UserScreen
{
    public static class Menu
    {
        public static void UserMenuScreen()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DO USUÁRIO");
            System.Console.WriteLine("-----------------");

            System.Console.WriteLine("Escolha a opção que deseja?");

            System.Console.WriteLine("1 - Listar Usuários");
            System.Console.WriteLine("2 - Listar Usuário (1)");
            System.Console.WriteLine("4 - Incluir Usuário");
            System.Console.WriteLine("5 - Atualizar Usuário");
            System.Console.WriteLine("6 - Deletar Usuário");

            System.Console.WriteLine();

            System.Console.Write("R: ");
            var response = int.Parse(System.Console.ReadLine()!);
        }
    }
}
