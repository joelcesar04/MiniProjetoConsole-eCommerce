using eCommerce.Console.Database;
using eCommerce.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.ClientScreen
{
    public static class DeleteClient
    {
        public static void LoadDelete()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DO CLIENTE");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            System.Console.Write("Qual o código do cliente que deseja deletar? ");
            var codigo = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            Delete(codigo);

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.ClientMenu();
        }

        private static void Delete(int codigo)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new ClientRepository(context);
                var client = repository.Get(codigo);

                try
                {
                    repository.Delete(client);
                    System.Console.WriteLine($"O cliente ({client.ClienteId}) foi deletado com sucesso!");
                    Thread.Sleep(2000);

                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível deletar o cliente!");
                    System.Console.WriteLine(ex.Message);
                    System.Console.ReadKey();

                }
            }
        }
    }
}
