using System;
using System.Data;
using MySql.Data.MySqlClient;
using FormGaragem.Config;
using System.Windows.Forms;

namespace FormGaragem.Helpers
{
    public class Banco
    {
        public static MySqlConnection connection;
        public static MySqlCommand cmd;
        public static MySqlDataAdapter adapter;
        public static DataTable dt;

        public static env config;

        public void openConnection()
        {
            try
            {
                connection = new MySqlConnection($"server={config.server};port={config.porta};uid={config.uid};pwd={config.pwd}");
                connection.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "[001] - Erro ao tentar abrir uma conexão estavél com o MySql.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void closeConnection()
        {
            try
            {
                connection.Close();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "[002] - Erro ao tentar fechar uma conexão com o MySql.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
