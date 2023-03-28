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

        //Usuários Padrões
        public static string nome1 = "GABRIEL OLIVEIRA";
        public static string email1 = "g38789138@gmail.com";
        public static string senha1 = "123456";

        public static string nome2 = "GABRIELA MARTINS";
        public static string email2 = "gabi.martins@teste.com";
        public static string senha2 = "123456";

        public static string nome3 = "CHARLES SARTORI";
        public static string email3 = "charles@etec.com";
        public static string senha3 = "123456";
    }
}
