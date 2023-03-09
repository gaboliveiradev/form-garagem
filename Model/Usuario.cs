using System;
using FormGaragem.Helpers;
using MySql.Data.MySqlClient;

namespace FormGaragem.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public string autenticarLogin()
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand("SELECT nome, senha FROM usuario WHERE nome = @nome and senha = sha1(@senha)", Banco.connection);
                Banco.cmd.Parameters.AddWithValue("@nome", nome);
                Banco.cmd.Parameters.AddWithValue("@senha", senha);
                MySqlDataReader dr = Banco.cmd.ExecuteReader();
                Banco.closeConnection();

                string id = "";

                while (dr.Read())
                {
                    id = dr.GetString("id");
                }

                return id;
            }
            catch (Exception err)
            {
                Console.WriteLine($"[003] - Ocorreu um erro ao tentar autenticar um login. \n\n {err.Message}");
                return null;
            } finally
            {
                Banco.closeConnection();
            }
        }
    }
}
