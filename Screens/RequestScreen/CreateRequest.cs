using eCommerce.Console.Database;
using eCommerce.Console.Enums;
using eCommerce.Console.Models;
using eCommerce.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.RequestScreen
{
    public static class CreateRequest
    {
        public static void LoadCreate()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DOS PEDIDOS");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            System.Console.WriteLine("INFORMAÇÕES:");
            System.Console.Write(" Qual é o código do cliente que está efetuando o pedido? ");
            var codeClient = int.Parse(System.Console.ReadLine()!);
            System.Console.Write(" Qual é o tipo do pagamento? (1 - Debito, 2 - Crédito, 3 - PIX, 4 - Boleto): ");
            var typePayment = int.Parse(System.Console.ReadLine()!);
            ETipoPagamento tipoPagamentoEnum = (ETipoPagamento)typePayment;
            System.Console.Write(" Quais são os códigos dos produtos? (separados por espaço): ");
            var codesProducts = System.Console.ReadLine();
            List<string> listCodeProducts = new(codesProducts!.Split(' '));

            var newRequest = new Pedido
            {
                ClienteId = codeClient,
                TipoPagamento = tipoPagamentoEnum,
            };

            if (newRequest.ProdutosPedidos == null)
            {
                newRequest.ProdutosPedidos = new List<ProdutosPedidos>();
            }

            foreach (var codProduct in listCodeProducts)
            {
                var productId = int.Parse(codProduct);
                System.Console.Write(" Qual a quantidade de produtos? ");
                var quantity = int.Parse(System.Console.ReadLine()!);

                var produtoPedido = new ProdutosPedidos
                {
                    ProdutoId = productId,
                    Quantidade = quantity
                };

                newRequest.ProdutosPedidos!.Add(produtoPedido);
            }

            System.Console.WriteLine();
            Create(newRequest);

            System.Console.WriteLine();
            System.Console.WriteLine("Retornando ao menu...");
            Thread.Sleep(2000);
            Menus.RequestMenu();
        }

        private static void Create(Pedido newRequest)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new RequestRepository(context);
                try
                {
                    repository.Create(newRequest);
                    System.Console.WriteLine("Pedido Cadastrado!");
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível cadastrar o pedido!");
                    System.Console.WriteLine(ex.Message);
                    System.Console.WriteLine(ex.InnerException!.Message);
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
