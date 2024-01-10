using eCommerce.Console.Database;
using eCommerce.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.RequestScreen
{
    public static class DeleteRequest
    {
        public static void LoadDelete()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PEDIDOS");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            System.Console.Write("Qual o N° do pedido que deseja cancelar? ");
            var codigo = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            Delete(codigo);

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.RequestMenu();
        }

        private static void Delete(int codigo)
        {
            using (var eCommerceContext = new eCommerceContext())
            {
                var repository = new RequestRepository(eCommerceContext);
                var request = repository.Get(codigo);

                try
                {
                    repository.Delete(request);
                    System.Console.WriteLine($"O pedido N° ({request.PedidoId}) foi cancelado com sucesso!");
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível cancelar o pedido!");
                    System.Console.WriteLine(ex.Message);
                    System.Console.ReadKey();
                }
            }
        }
    }
}
