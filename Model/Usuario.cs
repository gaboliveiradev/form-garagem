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

        public bool autenticarLogin()
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand("USE garagem_db; SELECT id FROM usuario WHERE nome = @nome and senha = sha1(@senha)", Banco.connection);
                Banco.cmd.Parameters.AddWithValue("@nome", nome);
                Banco.cmd.Parameters.AddWithValue("@senha", senha);
                MySqlDataReader dr = Banco.cmd.ExecuteReader();

                string id = "";

                while (dr.Read())
                {
                    id = dr.GetString("id");
                }

                return (id != "") ? true : false;
            }
            catch (Exception err)
            {
                Console.WriteLine($"[003] - Ocorreu um erro ao tentar autenticar um login. \n\n {err.Message}");
                return false;
            } finally
            {
                Banco.closeConnection();
            }
        }
    }
}
