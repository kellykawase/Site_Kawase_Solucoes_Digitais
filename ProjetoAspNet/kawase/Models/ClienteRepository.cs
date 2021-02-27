using System.Collections.Generic;
using MySqlConnector;
namespace Kawase.Models
{
    public class ClienteRepository
    {
        private const string _strConexao = "Database=kawase; Data Source=localhost; User Id=root;";
        public void Insert(Cliente novoCliente)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql= "INSERT INTO mensagem (Nome, Email, Telefone, Selecao, Descricao) VALUES (@Nome, @Email, @Telefone, @Selecao, @Descricao)";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Nome", novoCliente.Nome);
            comando.Parameters.AddWithValue("@Email", novoCliente.Email);
            comando.Parameters.AddWithValue("@Telefone", novoCliente.Telefone);
            comando.Parameters.AddWithValue("@Selecao", novoCliente.Selecao);
            comando.Parameters.AddWithValue("@Descricao", novoCliente.Descricao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void Remover(int Id)
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql= "DELETE FROM mensagem WHERE Id=@Id";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.Parameters.AddWithValue("@Id", Id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public List<Cliente> Query()
        {
            MySqlConnection conexao = new MySqlConnection(_strConexao);
            conexao.Open();
            string sql = "SELECT * FROM mensagem ORDER BY email";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Cliente> lista = new List<Cliente>();
            while (reader.Read())
            {
                Cliente csr = new Cliente();
                csr.Id = reader.GetInt32("Id");

                if(!reader.IsDBNull(reader.GetOrdinal("Nome")))
                    csr.Nome = reader.GetString("Nome");
                if(!reader.IsDBNull(reader.GetOrdinal("Email")))
                    csr.Email = reader.GetString("Email");
                if(!reader.IsDBNull(reader.GetOrdinal("Telefone")))
                    csr.Telefone = reader.GetString("Telefone");
                if(!reader.IsDBNull(reader.GetOrdinal("Selecao")))
                    csr.Selecao = reader.GetString("Selecao");
                if(!reader.IsDBNull(reader.GetOrdinal("Descricao")))
                    csr.Descricao = reader.GetString("Descricao");

                lista.Add(csr);
            }

            conexao.Close();
            return lista;
            }
        }
        
    }
