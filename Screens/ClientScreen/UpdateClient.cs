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
    public static class UpdateClient
    {
        public static void LoadUpdate()
        {
            System.Console.Clear();

            System.Console.WriteLine("ÁREA DO CLIENTE");
            System.Console.WriteLine("-----------------");
            System.Console.WriteLine();
            System.Console.Write("Qual o código do cliente que deseja atualizar? ");
            var codigo = int.Parse(System.Console.ReadLine()!);
            System.Console.WriteLine();

            System.Console.WriteLine("INFORMAÇÕES:");
            System.Console.Write(" Nome do Cliente: ");
            var name = System.Console.ReadLine();
            System.Console.Write(" E-mail do Cliente: ");
            var email = System.Console.ReadLine();
            System.Console.Write(" Gênero do Cliente (M/F): ");
            var gender = System.Console.ReadLine();
            while (gender!.Length > 1)
            {
                System.Console.WriteLine("----------------------------");
                System.Console.WriteLine(" INVALIDO! INSIRA M ou F.");
                System.Console.WriteLine(" TENTE NOVAMENTE!");
                System.Console.WriteLine("----------------------------");
                Thread.Sleep(3000);

                System.Console.Write(" Gênero do Cliente (M/F): ");
                gender = System.Console.ReadLine();
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
                ClienteId = codigo,
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

            System.Console.WriteLine();
            Update(client, codigo);

            System.Console.WriteLine();
            System.Console.WriteLine("Retornando ao menu...");
            Thread.Sleep(2000);
            Menus.ClientMenu();
        }

        private static void Update(Cliente client, int codigo)
        {
            using(var context = new eCommerceContext())
            {
                var repository = new ClientRepository(context);
                var cliente = repository.Get(codigo);
                try
                {
                    if (cliente != null)
                    {
                        cliente.Nome = client.Nome;
                        cliente.Email = client.Email;
                        cliente.Sexo = client.Sexo;
                        cliente.RG = client.RG;
                        cliente.CPF = client.CPF;
                        cliente.Contato.DDD = client.Contato.DDD;
                        cliente.Contato.Celular = client.Contato.Celular;
                        cliente.Endereco.NomeEndereco = client.Endereco.NomeEndereco;
                        cliente.Endereco.Numero = client.Endereco.Numero;
                        cliente.Endereco.Bairro = client.Endereco.Bairro;
                        cliente.Endereco.Cidade = client.Endereco.Cidade;
                        cliente.Endereco.Estado = client.Endereco.Estado;
                        cliente.Endereco.CEP = client.Endereco.CEP;
                        cliente.Endereco.Complemento = client.Endereco.Complemento;
                        context.SaveChanges();
                    }
                    System.Console.WriteLine($"O cliente ({client.ClienteId}) foi atualizado com sucesso!");
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Não foi possível atualizar o cliente!");
                    System.Console.WriteLine(ex.Message);
                    System.Console.ReadKey();
                }
            }
        }
    }
}
