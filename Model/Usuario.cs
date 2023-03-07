using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                new Conn().openConnection();
                new Conn().cmd = new MySqlCommand("SELECT nome, senha FROM usuario WHERE nome = @nome and senha = sha1(@senha);");

                new Conn().cmd.Parameters.AddWithValue("@nome", this.nome);
                new Conn().cmd.Parameters.AddWithValue("@senha", this.senha);
                MySqlDataReader dr = new Conn().cmd.ExecuteReader();

                new Conn().closeConnection();

                string nome = "", senha = "";

                while (dr.Read())
                {
                    nome = dr.GetString("nome");
                    senha = dr.GetString("senha");
                }

                return (this.nome == nome && this.senha == senha) ? true : false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "[003] - Erro na classe \"Usuario.cs\" | Metodo \"autenticarLogin();\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                new Conn().closeConnection();
                return false;
            } 
            finally 
            { 
                new Conn().closeConnection(); 
            }
        }
    }
}
