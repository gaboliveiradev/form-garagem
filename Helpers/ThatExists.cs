using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FormGaragem.Helpers
{
    public class ThatExists
    {
        public bool exists(string query, string tableName)
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand($"SELECT id FROM {tableName} WHERE nome = \"{query}\"", Banco.connection);
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
                MessageBox.Show(err.Message, "[004] - Erro ao tentar verificar a existencia de um dado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Banco.closeConnection();
            }
        }
    }
}
