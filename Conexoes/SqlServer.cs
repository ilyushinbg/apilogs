using System.Data.SqlClient;
using System.IO;

namespace APILogs.Conexoes
{
    public class SqlServer
    {
        private readonly SqlConnection _conexao;

        public SqlServer()
        {
            string stringConexao = File.ReadAllText(@"C:\Users\Ilyushin\Downloads\strConexaoLogs.txt");
            _conexao = new SqlConnection(stringConexao);
        }

        public void InserirLog(Entidades.Log log)
        {
            try
            {
                _conexao.Open();

                string query = @"INSERT INTO LogAplicacao
                                       (DataHora
                                       ,MensagemErro
                                       ,RastreioErro
                                       ,NomeMaquina
                                       ,NomeAplicacao
                                       ,Usuario)
                                 VALUES
                                       (@DataHora
                                       ,@MensagemErro
                                       ,@RastreioErro
                                       ,@NomeMaquina
                                       ,@NomeAplicacao
                                       ,@Usuario);";

                using (var cmd = new SqlCommand(query, _conexao))
                {
                    // adiciona o parametro e valor mapeado na query acima
                    cmd.Parameters.AddWithValue("@DataHora", log.DataHora);
                    cmd.Parameters.AddWithValue("@MensagemErro", log.MensagemErro);
                    cmd.Parameters.AddWithValue("@RastreioErro", log.RastreioErro);
                    cmd.Parameters.AddWithValue("@NomeMaquina", log.NomeMaquina);
                    cmd.Parameters.AddWithValue("@NomeAplicacao", log.NomeAplicacao);
                    cmd.Parameters.AddWithValue("@Usuario", log.Usuario);


                    // envia o insert para o banco de dados
                    cmd.ExecuteNonQuery();
                }
            }

            finally
            {
                _conexao.Close();
            }
        }

    }
}
