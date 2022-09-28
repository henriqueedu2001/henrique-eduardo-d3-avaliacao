using AcessoUsuario.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace AcessoUsuario.database {
    public static class LeitorSQL {
        /// <summary>
        /// retorna o um usuário com base no banco de dados
        /// busca feita por email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private static readonly string stringConexao = "Server=labsoft.pcs.usp.br; Initial Catalog=db_11; User id=usuario_11; pwd=48457508806;";
        public static bool CredenciaisVerificadas(string email, string senha) {
            bool encontrado = false;

            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelect = "SELECT * FROM UsersLoginInfo";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) {
                    rdr = cmd.ExecuteReader();
                    string email_tabela, senha_tabela;
                    // compara cada linha da tabela com os dados do cliente
                    while (rdr.Read()) {
                        email_tabela = rdr[0].ToString();
                        senha_tabela = rdr[1].ToString();
                        if(email_tabela == email && senha_tabela == senha) {
                            encontrado = true;
                            break;
                        }
                    }
                }
                con.Close();
            }
            return encontrado;
        }
        /// <summary>
        /// Busca na base de dados o usuário e retorna suas informações no objeto Usuario
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static Usuario GetUsuario (string email) {
            Usuario usuario = new Usuario();
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM UserPersonalInfo";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) {
                    rdr = cmd.ExecuteReader();
                    string email_tabela;
                    // busca na tabela o email do cliente e trz os dados
                    while (rdr.Read()) {
                        email_tabela = rdr[2].ToString();
                        if (email_tabela == email) {
                            usuario.Id = rdr[0].ToString();
                            usuario.Nome = rdr[1].ToString();
                            usuario.Email = rdr[2].ToString();
                            usuario.Curso = rdr[3].ToString();
                            usuario.Ocupacao = rdr[4].ToString();
                            break;
                        }
                    }
                }
                con.Close();
            }
            return usuario;
        }
    }
}
