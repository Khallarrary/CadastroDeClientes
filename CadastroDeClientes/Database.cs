using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CadastroDeClientes
{
    internal class Database
    {
        private readonly string connectionString = "Server=localhost;Database=CadastroDB;User=root;Password=nova_senha;";

        public MySqlConnection GetConnection() { 
        
        return new MySqlConnection(connectionString);
            
        }

    }
}
