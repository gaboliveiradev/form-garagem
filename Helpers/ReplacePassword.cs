using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormGaragem.Helpers
{
    public class ReplacePassword
    {

        public bool replacePassword(string nova_senha, string email)
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand($"UPDATE Usuario SET senha = sha1({nova_senha}) WHERE id = {getIdUser(email)}", Banco.connection);
                MySqlDataReader dr = Banco.cmd.ExecuteReader();

                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "[005] - Erro ao tentar atualizar a senha de um usuário.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Banco.closeConnection();
            }
        }

        public int getIdUser(string email)
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand($"SELECT id FROM usuario WHERE email = \"{email}\"", Banco.connection);
                MySqlDataReader dr = Banco.cmd.ExecuteReader();
                Banco.closeConnection();

                return int.Parse(dr.GetString("id"));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "[006] - Erro ao tentar pegar o id de um usuário pelo email.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                Banco.closeConnection();
            }
        }
    }
}
