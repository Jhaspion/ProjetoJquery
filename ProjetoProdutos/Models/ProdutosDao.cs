using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoProdutos.Models
{
    public class ProdutosDao
    {
        SqlConnection conn = new SqlConnection(@"Data Source=APEX04\SQLEXPRESS;Initial Catalog=PRODUTOS;Integrated Security=True");
        public List<Produto> ExibiProdutos()
        {
            List<Produto> listaProdutos = new List<Produto>();
            conn.Open();
            string query = @"SELECT [Id]
                            ,[Descricao]
                            ,[valor]
                             FROM [dbo].[Produto] ORDER BY Descricao";
            SqlCommand cmd = new SqlCommand(query,conn);
            using (SqlDataReader reader = cmd.ExecuteReader() ) 
            {
                while (reader.Read())
                {
                    Produto p = new Produto();
                    p.Id = Convert.ToInt32(reader["Id"]);
                    p.Descricao = reader["Descricao"].ToString();
                    p.Valor = Convert.ToInt32(reader["valor"]);
                    listaProdutos.Add(p);
                }
            }
                return listaProdutos;
        }
        public void InserirRegistro(string descricao, int valor)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"INSERT INTO [dbo].[Produto]
                             ([Descricao]
                             ,[valor])
                             VALUES(@descricao,@valor)";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@descricao", descricao);
            cmd.Parameters.AddWithValue("@valor",valor);
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw;
            }
        }
            public void DeletarRegistro(int id)
            {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"DELETE FROM Produto WHERE Id = "+id+"";
            cmd.Connection = conn;
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw;
            }
            }
    }
}