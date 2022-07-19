using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaRecebimento.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {
            var ret = false;

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = "Data Source=localhost;Initial Catalog=devdb;User Id=admin;Password=123";
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("SELECT COUNT(*)  FROM usuario WHERE usuario = '{0}' AND SENHA = '{1}'", login, senha);
                    ret = ((int)comando.ExecuteScalar() > 0);
                }
            }
            return ret;
        }
    }
}