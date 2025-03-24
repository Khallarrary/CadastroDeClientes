using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace CadastroDeClientes
{
    class Autenticacao
    {
        private const string arquivoUsuarios = "usuarios_hash.txt";
        private const string usuarioPadrao = "admin";
        private const string senhaPadrao = "admin";

        public Autenticacao()
        {
            InicializarUsuarioPadrao();
        }

        private void InicializarUsuarioPadrao()
        {
            if(!File.Exists(arquivoUsuarios))
            {
                File.Create(arquivoUsuarios).Close();
            }

            if (!UsuarioExiste(usuarioPadrao)) {
                string usuarioAdmin = $"{usuarioPadrao}:{GerarHash(senhaPadrao)}";
                File.AppendAllText(arquivoUsuarios, usuarioAdmin + Environment.NewLine);
                Console.WriteLine("Usuário admin criado com sucesso! (Usuário: admin, Senha: admin)");
            }

        }

        public bool Autenticar(string usuario, string senha)
        {
            if (!File.Exists(arquivoUsuarios)) return false;

            string[] linhas = File.ReadAllLines(arquivoUsuarios);
            foreach (var linhaa in linhas)
            {

                var partes = linhaa.Split(':');
                if (partes.Length == 2 && partes[0] == usuario && partes[1] == GerarHash(senha))
                {
                    return true;
                }
            }
            return false;

        }

        public void RegistrarUsuario(string usuario, string senha)
        {
            if (UsuarioExiste(usuario))
            {
                Console.WriteLine("Usuario ja existe");
                return;
            }

            string novoUsuario = $"{usuario}:{GerarHash(senha)}";
            File.AppendAllText(arquivoUsuarios, novoUsuario + Environment.NewLine);
            Console.WriteLine("Usuario registrado com sucesso!");

        }

        private bool UsuarioExiste(string usuario)
        {
            if (!File.Exists(arquivoUsuarios)) return false;

            string[] linhas = File.ReadAllLines(arquivoUsuarios);
            foreach (var linha in linhas)
            {
                var partes = linha.Split(":");
                if (partes.Length == 2 && partes[0] == usuario)
                {
                    return true;
                }
            }
            return false;
        }

        private string GerarHash(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }


        }
    }
}