using System.Collections.Generic;
using MySqlConnector;
namespace Kawase.Models
{
    public class UsuarioRepository
    {
        private const string _strConexao = "Database=kawase; Data Source=localhost; User Id=root;";
        public void Insert(Usuario novoUsuario)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql= "INSERT INTO usuario(nome, login, senha) VALUES (@Nome, @Login, @Senha)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Nome", novoUsuario.Nome);
            comando.Parameters.AddWithValue("@Login", novoUsuario.Login);
            comando.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        
        public void Atualizar(Usuario novoUsuario)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql= "UPDATE Usuario SET Nome=@Nome, Login=@Login, Senha=@Senha WHERE Id=@Id";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Nome", novoUsuario.Nome);
            comando.Parameters.AddWithValue("@Login", novoUsuario.Login);
            comando.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
            comando.Parameters.AddWithValue("@Id", novoUsuario.Id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
        
        public Usuario BuscarPorId(int Id)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql= "SELECT * FROM Usuario WHERE Id=@Id";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Id", Id);
            MySqlDataReader reader = comando.ExecuteReader();

                Usuario usr = new Usuario();
                if(reader.Read())
                {
                usr.Id = reader.GetInt32("Id");

                if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                usr.Nome = reader.GetString("Nome");

                if(!reader.IsDBNull(reader.GetOrdinal("Login")))
                usr.Login = reader.GetString("Login");
                if(!reader.IsDBNull(reader.GetOrdinal("Senha")))
                usr.Senha = reader.GetString("Senha");
               }

            conexao.Close();
            return usr;
        }

        public List<Usuario> Query()
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "SELECT * FROM Usuario ORDER BY nome";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Usuario> lista = new List<Usuario>();
            while (reader.Read())
            {
                Usuario usr = new Usuario();
                usr.Id = reader.GetInt32("Id");

                if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                usr.Nome = reader.GetString("Nome");

                if(!reader.IsDBNull(reader.GetOrdinal("Login")))
                usr.Login = reader.GetString("Login");
                if(!reader.IsDBNull(reader.GetOrdinal("Senha")))
                usr.Senha = reader.GetString("Senha");
                lista.Add(usr);
            }
            conexao.Close();
            return lista;
            }

        
        }
        
    }
