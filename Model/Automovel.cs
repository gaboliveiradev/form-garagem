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
    public class Automovel
    {
        public int id { get; set; }
        public string modelo { get; set; }
        public string ano { get; set; }
        public string placa { get; set; }
        public string cor { get; set; }
        public string quilometragem { get; set; }
        public int id_fabricante { get; set; }
        public int id_tipo { get; set; }
        public int id_combustivel { get; set; }
        public int id_extras { get; set; }
        public bool revisao { get; set; }
        public bool sinistro { get; set; }
        public bool furto { get; set; }
        public bool aluguel { get; set; }
        public bool venda { get; set; }
        public bool particular { get; set; }
        public string observacao { get; set; }

        public bool Incluir()
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand("INSERT INTO automovel (modelo, ano, placa, cor, quilometragem, id_fabricante, id_tipo, id_combustivel, revisao, sinistros, furto, aluguel, venda, particular, observacao) VALUES (@modelo, @ano, @placa, @cor, @quilometragem, @id_fabricante, @id_tipo, @id_combustivel, @revisao, @sinistros, @furto, @aluguel, @venda, @particular, @observacao)", Banco.connection);
                Banco.cmd.Parameters.AddWithValue("@modelo", modelo);
                Banco.cmd.Parameters.AddWithValue("@ano", ano);
                Banco.cmd.Parameters.AddWithValue("@placa", placa);
                Banco.cmd.Parameters.AddWithValue("@cor", cor);
                Banco.cmd.Parameters.AddWithValue("@quilometragem", quilometragem);
                Banco.cmd.Parameters.AddWithValue("@id_fabricante", id_fabricante);
                Banco.cmd.Parameters.AddWithValue("@id_tipo", id_tipo);
                Banco.cmd.Parameters.AddWithValue("@id_combustivel", id_combustivel);
                Banco.cmd.Parameters.AddWithValue("@revisao", revisao);
                Banco.cmd.Parameters.AddWithValue("@sinistros", sinistro);
                Banco.cmd.Parameters.AddWithValue("@furto", furto);
                Banco.cmd.Parameters.AddWithValue("@aluguel", aluguel);
                Banco.cmd.Parameters.AddWithValue("@venda", venda);
                Banco.cmd.Parameters.AddWithValue("@particular", particular);
                Banco.cmd.Parameters.AddWithValue("@observacao", observacao);
                Banco.cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine($"[005] - Ocorreu um erro ao tentar incluir um combustivel no banco de dados. \n\n {err.Message}");
                return false;
            }
            finally
            {
                Banco.closeConnection();
            }
        }

        public DataTable Query()
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand("SELECT a.modelo, a.placa, a.ano, a.quilometragem, a.cor, f.nome as fabricante, c.nome as combustivel, t.nome as tipo, a.revisao, a.sinistros, a.furto, a.aluguel, a.venda, a.particular, a.observacao FROM Automovel a \r\nJOIN Fabricante f ON (f.id = id_fabricante)\r\nJOIN Combustivel c ON (c.id = id_combustivel)\r\nJOIN Tipo t ON (t.id = id_tipo);", Banco.connection);
                Banco.adapter = new MySqlDataAdapter(Banco.cmd);
                Banco.dt = new DataTable();
                Banco.adapter.Fill(Banco.dt);
                Banco.closeConnection();

                return Banco.dt;
            }
            catch (Exception err)
            {
                Console.WriteLine($"[006] - Ocorreu um erro ao tentar consultar um automovel no banco de dados. \n\n {err.Message}");
                return null;
            }
        }
    }
}
