using eCommerce.Console.Screens;

namespace eCommerce.Console
{
    public class Program
    {
        public static void Main()
        {
            System.Console.Clear();
            System.Console.WriteLine("SEJÁ BEM-VINDO!");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine("O que gostaria de gerenciar?");

            System.Console.WriteLine();

            System.Console.WriteLine("1 - Acessar a área do Cliente");
            System.Console.WriteLine("2 -");
            System.Console.WriteLine("3 - Acessar a área de Produtos");
            System.Console.WriteLine("4 - Acessar a área de Categorias");

            System.Console.WriteLine();

            System.Console.Write("R: ");
            var response = System.Console.ReadLine();

            switch (response)
            {
                case "1":
                    Menus.ClientMenu();
                    break;
                case "3":
                    Menus.ProductMenu();
                    break;
                case "4":
                    Menus.CategoryMenu();
                    break;
                default:
                    Main();
                    break;
            }
        }
    }
}