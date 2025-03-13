using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes
{
    public class Clientes
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }



        public static Clientes CadastrarCliente() {

            Clientes novoCliente = new Clientes();

            Console.WriteLine("Digite o nome do novo cliente: ");
            novoCliente.Nome = Console.ReadLine();
            Console.WriteLine("Digite a idade do novo cliente: ");
            novoCliente.Idade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o cpf do novo cliente: ");
            novoCliente.Cpf = Console.ReadLine();

            return novoCliente;

        }

        public static void ConsultarClientes(List<Clientes> lista) {
            Console.Clear();


            Console.WriteLine("Clientes Cadastrados");

            if (lista.Count == 0)
            {

                Console.WriteLine("Sem cliente cadastrado");
            }
            else
            {
                foreach (var cliente in lista)
                {
                    Console.WriteLine($"Nome: {cliente.Nome}, Idade: {cliente.Idade}, Cpf: {cliente.Cpf}\n");
                }

                
            }
        }
    }
}

