using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FormGaragem.Config;
using Renci.SshNet.Messages;
using System.Windows.Forms;

namespace FormGaragem.Helpers
{
    public class MySQL
    {
        public static MySqlConnection connection;
        public static MySqlCommand cmd;
        public static MySqlDataAdapter adapter;
        public static DataTable dt;

        public static env config;

        public static void openConnection()
        {
            try
            {
                connection = new MySqlConnection($"server={config.server};port={config.porta};uid={config.uid};pwd={config.pwd}");
                connection.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "[001] - Erro na classe \"MySQL.cs\" | Metodo \"openConnection();\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void closeConnection()
        {
            try
            {
                connection.Close();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "[002] - Erro na classe \"MySQL.cs\" | Metodo \"closeConnection();\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
