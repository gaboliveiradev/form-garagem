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

        public static void openConnection()
        {
            try
            {
                connection = new MySqlConnection($"server={env.server};port={env.porta};uid={env.uid};pwd={env.pwd}");
                connection.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "[001] - Erro ao tentar abrir uma conexão estavél com o MySql.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void closeConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "[002] - Erro ao tentar fechar uma conexão com o MySql.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void createDB()
        {
            try
            {
                openConnection();

                cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS garagem_db; USE garagem_db", connection);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS `combustivel` (\r\n  `id` int NOT NULL AUTO_INCREMENT,\r\n  `nome` varchar(100) NOT NULL,\r\n  PRIMARY KEY (`id`)\r\n) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;", connection);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS `fabricante` (\r\n  `id` int NOT NULL AUTO_INCREMENT,\r\n  `nome` varchar(100) NOT NULL,\r\n  PRIMARY KEY (`id`)\r\n) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;", connection);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS `tipo` (\r\n  `id` int NOT NULL AUTO_INCREMENT,\r\n  `nome` varchar(100) NOT NULL,\r\n  PRIMARY KEY (`id`)\r\n) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;", connection);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS `usuario` (\r\n  `id` int NOT NULL AUTO_INCREMENT,\r\n  `nome` varchar(100) NOT NULL,\r\n  `email` varchar(150) NOT NULL,\r\n  `senha` varchar(150) NOT NULL,\r\n  PRIMARY KEY (`id`)\r\n) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;", connection);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS `automovel` (\r\n  `id` int NOT NULL AUTO_INCREMENT,\r\n `modelo` varchar(100) NOT NULL,\r\n  `ano` int NOT NULL,\r\n   `placa` varchar(20) NOT NULL,\r\n  `cor` varchar(50) NOT NULL,\r\n  `quilometragem` varchar(100) NOT NULL,\r\n  `id_fabricante` int NOT NULL,\r\n  `id_tipo` int NOT NULL,\r\n  `id_combustivel` int NOT NULL,\r\n `revisao` tinyint(1) NOT NULL DEFAULT '0',\r\n  `sinistros` tinyint(1) NOT NULL DEFAULT '0',\r\n  `furto` tinyint(1) NOT NULL DEFAULT '0',\r\n  `aluguel` tinyint(1) NOT NULL DEFAULT '0',\r\n  `venda` tinyint(1) NOT NULL DEFAULT '0',\r\n  `particular` tinyint(1) NOT NULL DEFAULT '0',\r\n  `observacao` text NOT NULL\r\n,  PRIMARY KEY (`id`),\r\n  KEY `id_fabricante` (`id_fabricante`),\r\n  KEY `id_tipo` (`id_tipo`),\r\n  KEY `id_combustivel` (`id_combustivel`),\r\n  CONSTRAINT `automovel_ibfk_1` FOREIGN KEY (`id_fabricante`) REFERENCES `fabricante` (`id`),\r\n  CONSTRAINT `automovel_ibfk_2` FOREIGN KEY (`id_tipo`) REFERENCES `tipo` (`id`),\r\n  CONSTRAINT `automovel_ibfk_3` FOREIGN KEY (`id_combustivel`) REFERENCES `combustivel` (`id`)) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;", connection);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand($"INSERT INTO Usuario (nome, email, senha) VALUES (\"{env.nome1}\", \"{env.email1}\", sha1(\"{env.senha1}\"))", connection);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand($"INSERT INTO Usuario (nome, email, senha) VALUES (\"{env.nome2}\", \"{env.email2}\", sha1(\"{env.senha2}\"))", connection);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand($"INSERT INTO Usuario (nome, email, senha) VALUES (\"{env.nome3}\", \"{env.email3}\", sha1(\"{env.senha3}\"))", connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "[003] - Erro ao tentar criar o banco de dados MySql.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally
            {
                closeConnection();
            }
        }
    }
}
