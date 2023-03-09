namespace FormGaragem.Config
{
    public static class env
    {
        // Configuração de Email SMTP
        public static string email = "mocadaautomoveis@hotmail.com";
        public static string senha = "etecjau070";

        public static string servidor_smtp = "smtp.office365.com";
        public static int porta_smtp = 587;

        // Configuração do Banco de Dados MySql
        public static string server = "localhost";
        public static string porta = "3307";
        public static string uid = "root";
        public static string pwd = "mysqldev@2835";
    }
}
