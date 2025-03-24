using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CadastroDeClientes
{
    public class Clientes
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }



        public static void CadastrarCliente()
        {

            Clientes novoCliente = new Clientes();

            Console.WriteLine("Digite o nome do novo cliente: ");
            novoCliente.Nome = Console.ReadLine();
            Console.WriteLine("Digite a idade do novo cliente: ");
            novoCliente.Idade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o cpf do novo cliente: ");
            novoCliente.Cpf = Console.ReadLine();

            

            Database db = new Database();
            {
                using (var conn = db.GetConnection())
                {

                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO Clientes (Nome, Idade, Cpf) VALUES (@Nome, @Idade, @Cpf)";
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Nome", novoCliente.Nome);
                            cmd.Parameters.AddWithValue("@Idade", novoCliente.Idade);
                            cmd.Parameters.AddWithValue("@Cpf", novoCliente.Cpf);
                            cmd.ExecuteNonQuery();

                        }
                        Console.WriteLine("Cliente cadastrado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro ao cadastrar cliente: " + ex.Message);
                    }

                }
            }

        }

        public static void ConsultarClientes() {
            Console.Clear();


            Console.WriteLine("Clientes Cadastrados");

            Database db = new Database();

            using (var conn = db.GetConnection()) {

                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Clientes";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows) {

                                Console.WriteLine("Nenhum cliente cadastrado.");        
                            } else
                            {
                                while (reader.Read()) {
                                    Console.WriteLine($"ID: {reader["Id"]} | Nome: {reader["Nome"]} | Idade: {reader["Idade"]} | Cpf: {reader["cpf"]}"); }
                                       
                            }

                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Erro ao consultar clientes: " + ex.Message);
                
                }
            }
        }
    }
}

