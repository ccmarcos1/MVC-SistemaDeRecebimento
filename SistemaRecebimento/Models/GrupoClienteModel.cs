using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaRecebimento.Models
{
    public class GrupoClienteModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public DateTime Datacriacao { get; set; }
        public int Nivel { get; set; }


        public static List<GrupoClienteModel> ListaUsuario(string consulta)
        {
            var ret = new List<GrupoClienteModel>();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from USUARIO order by ID";
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new GrupoClienteModel
                        {
                            Id = (int)reader["id"],
                            Usuario = (string)reader["usuario"],
                            Nivel = (int)reader["nivel"],
                            Datacriacao = (DateTime)reader["datacriacao"]
                        });
                    }
                }
            }

            return ret;

        }
    }
}