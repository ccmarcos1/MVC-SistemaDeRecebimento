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
        public static GrupoProdutoModel RecuperarPeloId(int id)
        {
            GrupoProdutoModel ret = null;

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("select * from PRODUTO where (id = {0})", id);
                    var reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        ret = new GrupoProdutoModel
                        {
                            Id = (int)reader["id"],
                            Nome = (string)reader["nome"],
                            Valor = (decimal)reader["valor"],
                            Quantidade = (int)reader["quantidade"],
                            Datahoracriacao = (DateTime)reader["datahoracriacao"]
                        };
                    }
                }
            }

            return ret;
        }
        public static bool ExcluirPeloId(int id)
        {
            var ret = false;

            if (RecuperarPeloId(id) != null)
            {
                using (var conexao = new SqlConnection())
                {
                    conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                    conexao.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;
                        comando.CommandText = string.Format("delete from PRODUTO where (id = {0})", id);
                        ret = (comando.ExecuteNonQuery() > 0);
                    }
                }
            }

            return ret;
        }
        public int Salvar()
        {
            var ret = 0;

            var model = RecuperarPeloId(this.Id);

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    if (model == null)
                    {
                        comando.CommandText = string.Format("insert into PRODUTO (nome, valor,quantidade,datahoracriacao) values ('{0}', {1}, {2}, getdate()); select convert(int, scope_identity())", this.Nome, this.Valor, this.Quantidade);
                        ret = (int)comando.ExecuteScalar();
                    }
                    else
                    {
                        comando.CommandText = string.Format(
                            "update PRODUTO set nome='{1}', valor={2},quantidade={3}, datahoracriacao={4} where id = {0}",
                            this.Id, this.Nome, this.Valor, this.Quantidade, this.Datahoracriacao);
                        if (comando.ExecuteNonQuery() > 0)
                        {
                            ret = this.Id;
                        }
                    }
                }
            }

            return ret;
        }
    }
}