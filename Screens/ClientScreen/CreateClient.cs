using eCommerce.Console.Database;
using eCommerce.Console.Models;
using eCommerce.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Console.Screens.ClientScreen
{
    public class CreateClient
    {
        public static void LoadCreate()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DO CLIENTE");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();

            System.Console.WriteLine("INFORMAÇÕES:");
            System.Console.Write(" Nome do Cliente: ");
            var name = System.Console.ReadLine();
            System.Console.Write(" E-mail do Cliente: ");
            var email = System.Console.ReadLine();
            System.Console.Write(" Gênero do Cliente (M/F): ");
            var gender = System.Console.ReadLine();
            if (gender!.Length > 1)
            {
                System.Console.WriteLine("----------------------------");
                System.Console.WriteLine(" INVALIDO! INSIRA M ou F.");
                System.Console.WriteLine(" TENTE NOVAMENTE!");
                System.Console.WriteLine("----------------------------");
                Thread.Sleep(3000);
                LoadCreate();
                return;
            }

            System.Console.Write(" RG: ");
            var rg = System.Console.ReadLine();
            System.Console.Write(" CPF: ");
            var cpf = System.Console.ReadLine();
            System.Console.WriteLine();

            System.Console.WriteLine("CONTATO:");
            System.Console.Write(" DDD: ");
            var ddd = System.Console.ReadLine();
            System.Console.Write(" N°: ");
            var numberPhone = System.Console.ReadLine();
            System.Console.WriteLine();

            System.Console.WriteLine("ENDEREÇO:");
            System.Console.Write(" Nome do Endereço: ");
            var address = System.Console.ReadLine();
            System.Console.Write(" N°: ");
            var numberAddress = int.Parse(System.Console.ReadLine()!);
            System.Console.Write(" Bairro: ");
            var neighborhood = System.Console.ReadLine();
            System.Console.Write(" Cidade: ");
            var city = System.Console.ReadLine();
            System.Console.Write(" Estado: ");
            var state = System.Console.ReadLine();
            System.Console.Write(" CEP: ");
            var zipCode = System.Console.ReadLine();
            System.Console.Write(" Complemento: ");
            var complement = System.Console.ReadLine();

            var client = new Cliente
            {
                Nome = name,
                Email = email,
                Sexo = gender,
                RG = rg,
                CPF = cpf,
                Contato =
                {
                    DDD = ddd,
                    Celular = numberPhone
                },
                Endereco =
                {
                    NomeEndereco = address,
                    Numero = numberAddress,
                    Bairro = neighborhood,
                    Cidade = city,
                    Estado = state,
                    CEP = zipCode,
                    Complemento = complement
                }
            };

            Create(client);

            System.Console.WriteLine("Retornando ao menu...");
            Thread.Sleep(2000);
            Menus.ClientMenu();
        }

        private static void Create(Cliente client)
        {
            using (var context = new eCommerceContext())
            {
                var repository = new ClientRepository(context);
                try
                {
                    repository.Create(client);
                    System.Console.WriteLine("Cliente Cadastrado!");
                    Thread.Sleep(2000);
                } catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível cadastrar o cliente!");
                    System.Console.WriteLine(ex.Message);
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
