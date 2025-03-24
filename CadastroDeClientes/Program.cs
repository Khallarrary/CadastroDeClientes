using CadastroDeClientes;
using System;
using System.Runtime.CompilerServices;
using System.Security.Permissions;


class Program {

    
    static void Main(string[] args)
    {

        Autenticacao auth = new Autenticacao();

        Console.WriteLine("Digite 1 para realizar o login");
        Console.WriteLine("Digite 0 para sair");
        int opcao = Convert.ToInt32(Console.ReadLine());

        if (opcao == 1)
        {
            Console.Write("Usuario: ");
            string usuario = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = LerSenha();

             if (auth.Autenticar(usuario, senha)){

                Console.Clear();
                Console.WriteLine("Seja bem-vindo, " + usuario + "!");
                ExibirMenu(auth);
                      

             }   else {
                Console.WriteLine("\nUsuario ou senha incorretos.");
            }
          
        } else if (opcao == 0) {
            Console.WriteLine("Encerrando...");
            Environment.Exit(0);
        }
            else{
            Console.WriteLine("Opcao invalida");
            }
    


        static string LerSenha()
        {
            string senha = "";
            ConsoleKeyInfo key;
            do { 
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    senha += key.KeyChar;
                    Console.Write("*");

                }
                else if (key.Key == ConsoleKey.Backspace && senha.Length > 0) { 
                
                    senha = senha.Substring(0, senha.Length - 1);
                    Console.Write("\b\b");

                }
            }while(key.Key != ConsoleKey.Enter);

            return senha;
        }


        static void PausarERetornar()
        {
            Console.WriteLine("\nPressione ENTER para voltar ao menu...");
            Console.ReadLine();
        }

        static void ExibirMenu(Autenticacao auth)
        {
            string MensagemBoasVindas;

            
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
                   "\nDigite 5 para registrar um novo usuario" +
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
                            Clientes.CadastrarCliente();
                            PausarERetornar();

                            break;

                        case 2:
                            Console.Clear();
                            Clientes.ConsultarClientes();
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

                        case 5:
                            Console.Clear();
                            Console.Write("Novo usuario: ");
                            string novoUsuario = Console.ReadLine();
                            Console.Write("Nova senha: ");
                            string novaSenha = LerSenha();
                            auth.RegistrarUsuario(novoUsuario, novaSenha);
                            PausarERetornar();

                            break;

                        case 0:
                            Console.Clear();
                            Console.WriteLine("Encerrando...");
                            return;

                        default:
                            Console.WriteLine("Opcao Invalida, tente novamente");
                            PausarERetornar();
                            break;

                    }

                }
            }
            else
            {
                Console.WriteLine("Encerrando...");

            }
        }
    }
}


