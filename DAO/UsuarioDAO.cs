using FormGaragem.Helpers;
using FormGaragem.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormGaragem.DAO
{
    public class UsuarioDAO
    {
        public MySqlDataReader autenticarLogin(UsuarioModel model)
        {
            try
            {
                new Conn().openConnection();
                new Conn().cmd = new MySqlCommand("SELECT nome, senha FROM usuario WHERE nome = @nome and senha = sha1(@senha);");

                new Conn().cmd.Parameters.AddWithValue("@nome", model.nome);
                new Conn().cmd.Parameters.AddWithValue("@senha", model.senha);

                new Conn().closeConnection();

                return new Conn().cmd.ExecuteReader();
            } 
            catch (Exception err)
            {
                MessageBox.Show("Erro", err.Message);
                return new Conn().cmd.ExecuteReader();
            }
            finally
            {
                new Conn().closeConnection();
            }
        } 
    }
}
