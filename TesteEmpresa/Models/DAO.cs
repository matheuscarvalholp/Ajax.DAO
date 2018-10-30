using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteEmpresa.Models
{
    public class DAO
    {
        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-Q6I8LRTT;Integrated Security=SSPI;Initial Catalog=Loja");


        public List<Produto> MostrarProdutos()
        {
            List<Produto> produtos = new List<Produto>();
            connection.Open();
            string query = @"SELECT [ID]
                             ,[DESCRICAO]
                             ,[QUANTIDADE]
                             ,[VALOR]
                             ,[DATA] 
                         FROM [dbo].[Produtos] ORDER BY [DESCRICAO]";
            SqlCommand command = new SqlCommand(query, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = Convert.ToInt32(reader["ID"]);
                    produto.Descricao = reader["DESCRICAO"].ToString();
                    produto.Quantidade = Convert.ToInt32(reader["QUANTIDADE"]);
                    produto.Valor = Convert.ToDecimal(reader["VALOR"]);
                    produto.Data = Convert.ToDateTime(reader["DATA"]);
                    produtos.Add(produto);
                }
            }
            return produtos;
        }
        public void InserirProduto(string descricao, int quantidade, decimal valor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = @"INSERT INTO [dbo].[Produtos]
                             ([DESCRICAO]
                             ,[QUANTIDADE]
                             ,[VALOR]
                             ,[DATA]) 
                             VALUES(@DESCRICAO,@QUANTIDADE,@VALOR,@DATA)";
                cmd.Parameters.AddWithValue("@DESCRICAO",descricao);
                cmd.Parameters.AddWithValue("@QUANTIDADE", quantidade);
                cmd.Parameters.AddWithValue("@VALOR", valor);
                cmd.Parameters.AddWithValue("@DATA", DateTime.Now);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void DeletarProduto(int id)
        {
            try
            {
                connection.Open();  //abre minha conexao com o meu banco de dados
                SqlCommand cmd = new SqlCommand();  /*SqlCommand é minha conexao -> cmd são meus dados*/
                cmd.Connection = connection;
                cmd.CommandText = @"DELETE FROM [dbo].[Produtos] where ID = " + id + "";
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public List<Produto> MostrarProdutos(int id)
        {
            List<Produto> produtos = new List<Produto>();
            connection.Open();
            string query = @"SELECT [ID]
                            ,[DESCRICAO]
                            ,[QUANTIDADE]
                            ,[VALOR]
                            ,[DATA]
                         FROM [dbo].[Produtos]";
                         if (id != 0)
            {
                query += " WHERE ID = " + id + "";
            }
           query += "ORDER BY[DESCRICAO]";
            SqlCommand command = new SqlCommand(query, connection);
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Produto produto = new Produto();
                    produto.Id = Convert.ToInt32(reader["ID"]);
                    produto.Descricao = reader["DESCRICAO"].ToString();
                    produto.Quantidade = Convert.ToInt32(reader["QUANTIDADE"]);
                    produto.Valor = Convert.ToDecimal(reader["VALOR"]);
                    produtos.Add(produto);


                }
            }
            return produtos;

        }
        public void Editar(int id, string descricao, int quantidade, decimal valor)
        {
            connection.Open();
            string query = @"UPDATE [dbo].[Produtos]
                           SET [DESCRICAO] = '"+ descricao +@"'
                          ,[QUANTIDADE] =  "+ quantidade +@"
                          ,[VALOR] = "+ valor +@"
                          ,[DATA] = GETDATE()
                          WHERE ID = "+ id +"";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}