using Azure.Core;
using eCommerce.Console.Database;
using eCommerce.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.RequestScreen
{
    public static class ListRequest
    {
        public static void Load()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PEDIDOS");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            List();

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.RequestMenu();
        }

        public static void LoadId()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PEDIDOS");
            System.Console.WriteLine("-----------------");
            System.Console.Write("Digite o N° do pedido que deseja buscar: ");
            var codigo = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            ListId(codigo);

            System.Console.WriteLine("CLIQUE EM QUALQUER TECLA PARA VOLTAR...");
            System.Console.ReadKey();
            Menus.RequestMenu();
        }

        private static void List()
        {
            using (var eCommerceContext = new eCommerceContext())
            {
                var repository = new RequestRepository(eCommerceContext);
                var requests = repository.Get();

                if (!requests.Any())
                {
                    System.Console.WriteLine("Nenhum pedido cadastrado. Por gentileza, efetue o cadastro.");
                    System.Console.ReadKey();

                    Menus.RequestMenu();
                }
                else
                {
                    foreach (var request in requests)
                    {
                        System.Console.WriteLine($"CLIENTE: {request.Cliente!.ClienteId} - {request.Cliente!.Nome}");
                        System.Console.WriteLine($" - N° PEDIDO: {request.PedidoId}");
                        System.Console.WriteLine($" - TIPO PAGAMENTO: {request.TipoPagamento}");
                        System.Console.WriteLine($" - PRODUTOS:");
                        foreach (var reqProduct in request.ProdutosPedidos!)
                        {
                            System.Console.WriteLine($"    {reqProduct.Produto.Nome} - {reqProduct.Produto.Preco}");
                            System.Console.WriteLine($"     QUANTIDADE: {reqProduct.Quantidade}");
                        }
                        System.Console.WriteLine();
                    }
                }
            }
        }
        private static void ListId(int codigo)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new RequestRepository(context);
                var request = repository.Get(codigo);

                if (request == null)
                {
                    System.Console.WriteLine($"O N° de pedido ({codigo}) não foi encontrado. Por gentileza, tente novamente.");
                    System.Console.ReadKey();

                    Menus.RequestMenu();
                }
                else
                {
                    System.Console.WriteLine($"CLIENTE: {request.Cliente!.ClienteId} - {request.Cliente!.Nome}");
                    System.Console.WriteLine($" - N° PEDIDO: {request.PedidoId}");
                    System.Console.WriteLine($" - TIPO PAGAMENTO: {request.TipoPagamento}");
                    System.Console.WriteLine($" - PRODUTOS:");
                    foreach (var reqProduct in request.ProdutosPedidos!)
                    {
                        System.Console.WriteLine($"    {reqProduct.Produto.Nome} - {reqProduct.Produto.Preco}");
                        System.Console.WriteLine($"     QUANTIDADE: {reqProduct.Quantidade}");
                    }
                    System.Console.WriteLine();
                }
            }
        }
    }
}
