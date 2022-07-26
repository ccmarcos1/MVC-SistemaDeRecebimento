using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaRecebimento.Models
{
    public class GrupoProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime Datahoracriacao { get; set; }

        public static List<GrupoProdutoModel> RecuperarLista(string consulta)
        {
            var ret = new List<GrupoProdutoModel>();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from PRODUTO order by ID";
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new GrupoProdutoModel
                        {
                            Id = (int)reader["id"],
                            Nome = (string)reader["nome"],
                            Valor = (decimal)reader["valor"],
                            Quantidade = (int)reader["quantidade"],
                            Datahoracriacao = (DateTime)reader["datahoracriacao"]
                        });
                    }
                }
            }

            return ret;

        }
    }
}