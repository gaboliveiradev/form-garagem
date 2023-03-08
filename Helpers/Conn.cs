using System;
using System.Data;
using MySql.Data.MySqlClient;
using FormGaragem.Config;
using System.Windows.Forms;

namespace FormGaragem.Helpers
{
    public class Conn
    {
        public static MySqlConnection connection;
        public MySqlCommand cmd;
        public static MySqlDataAdapter adapter;
        public static DataTable dt;

        public static env config;

        public void openConnection()
        {
            try
            {
                connection = new MySqlConnection($"server=localhost;port=3307;uid=root;pwd=etecjau");
                connection.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "[001] - Erro na classe \"Conn.cs\" | Metodo \"openConnection();\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void closeConnection()
        {
            try
            {
                connection.Close();
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "[002] - Erro na classe \"Conn.cs\" | Metodo \"closeConnection();\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
