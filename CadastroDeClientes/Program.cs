using CadastroDeClientes;
using System;
using System.Security.Permissions;


class Program {

    static List<Clientes> listaDeClientes = new List<Clientes>();
    static void Main(string[] args)
    {

        string MensagemBoasVindas;

        MensagemBoasVindas = "*****Seja bem-vindo!!!******\n\nO que deseja fazer?\n";
        Console.WriteLine(MensagemBoasVindas);
        Console.WriteLine("Digite 1 para entrar no Menu\nDigite 0 para sair");

        int OpcaoDesejada = Convert.ToInt32(Console.ReadLine());

        Console.Clear();

        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para cadastro de cliente." +
               "\nDigite 2 para verificar os clientes cadastrados." +
               "\nDigite 3 para editar dados de um cliente." +
               "\nDigite 4 para excluir um cliente." +
               "\nDigite 0 para sair.");

            return Convert.ToInt32(Console.ReadLine());
        }


        if (OpcaoDesejada == 1)
        {
            while (true)
            {
                int opcaoMenu = Menu();


                switch (opcaoMenu)
                {
                    case 1:
                        Console.Clear();
                        Clientes novoCliente = Clientes.CadastrarCliente();
                        listaDeClientes.Add(novoCliente);
                        Console.WriteLine("Cliente Cadastado com sucesso!");
                        PausarERetornar();

                        break;

                    case 2:
                        Console.Clear();
                        Clientes.ConsultarClientes(listaDeClientes);
                        PausarERetornar();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Funcionabilidade ainda nao atribuida!");
                        PausarERetornar();

                        break;


                    case 4:
                        Console.Clear();
                        Console.WriteLine("Funcionabilidade ainda nao atribuida!");
                        PausarERetornar();

                        break;

                    case 0:
                        Console.Clear();
                        Console.WriteLine("Encerrando...");
                        return;
                   
                    default: Console.WriteLine("Opcao Invalida, tente novamente");
                        PausarERetornar();
                        break;

                }

            }
        }
        else
        {
            Console.WriteLine("Encerrando...");
            
        }


        static void PausarERetornar()
        {
            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }
    }
}


