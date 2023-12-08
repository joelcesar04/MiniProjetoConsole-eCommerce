using eCommerce.Console.Screens;

Console.WriteLine("SEJÁ BEM-VINDO!");
Console.WriteLine("-----------------");
Console.WriteLine("O que gostaria de gerenciar?");

Console.WriteLine();

Console.WriteLine("1 - Acessar a área do Cliente");
Console.WriteLine("2 -");
Console.WriteLine("3 -");
Console.WriteLine("4 -");

Console.WriteLine();

Console.Write("R: ");
var response = int.Parse(Console.ReadLine()!);

switch(response)
{
    case 1:
        Menus.ClientMenu();
    break;
}