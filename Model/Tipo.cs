using FormGaragem.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGaragem.Model
{
    public class Tipo
    {
        public int id { get; set; }
        public string nome { get; set; }

        public bool Incluir()
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand("USE garagem_db; INSERT INTO tipo (nome) VALUES (@nome)", Banco.connection);
                Banco.cmd.Parameters.AddWithValue("@nome", nome);
                Banco.cmd.ExecuteNonQuery();
                Banco.closeConnection();
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine($"[007] - Ocorreu um erro ao tentar incluir um tipo no banco de dados. \n\n {err.Message}");
                return false;
            }
        }

        public DataTable Query()
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand("SELECT nome FROM Tipo;", Banco.connection);
                Banco.adapter = new MySqlDataAdapter(Banco.cmd);
                Banco.dt = new DataTable();
                Banco.adapter.Fill(Banco.dt);
                Banco.closeConnection();

                return Banco.dt;
            }
            catch (Exception err)
            {
                Console.WriteLine($"[006] - Ocorreu um erro ao tentar consultar um tipo no banco de dados. \n\n {err.Message}");
                return null;
            }
        }

        public DataTable GetTipo()
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand("SELECT * FROM Tipo;", Banco.connection);
                Banco.adapter = new MySqlDataAdapter(Banco.cmd);
                Banco.dt = new DataTable();
                Banco.adapter.Fill(Banco.dt);
                Banco.closeConnection();

                return Banco.dt;
            }
            catch (Exception err)
            {
                Console.WriteLine($"[006] - Ocorreu um erro ao tentar consultar um tipo de automovél no banco de dados. \n\n {err.Message}");
                return null;
            }
        }
    }
}
