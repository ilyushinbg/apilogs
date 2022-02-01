using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APILogs.Controllers
{
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly Conexoes.SqlServer _sql;
        public LogController()
        {
            _sql = new Conexoes.SqlServer();
        }

        [HttpPost("v1/Logs")]
        public IActionResult InserirLog(Entidades.Log log)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(log.NomeAplicacao) || log.NomeAplicacao.Length < 3 || log.NomeAplicacao.Length > 80) 
                    throw new InvalidOperationException("O nome da aplicação deve conter entre 1 a 80 caracteres.");

                if (string.IsNullOrEmpty(log.NomeMaquina) || log.NomeMaquina.Length < 3 || log.NomeMaquina.Length > 80)
                    throw new InvalidOperationException("O nome da máquina deve conter entre 1 a 80 caracteres.");

                if (string.IsNullOrEmpty(log.MensagemErro) || log.MensagemErro.Length < 5 || log.MensagemErro.Length > 3000)
                    throw new InvalidOperationException("A mensagem de erro deve conter entre 15 a 3000 caracteres.");

                if (string.IsNullOrEmpty(log.Usuario) || log.Usuario.Length < 5 || log.Usuario.Length > 20)
                    throw new InvalidOperationException("A mensagem de erro deve conter entre 5 a 20 caracteres.");


                _sql.InserirLog(log);
                return StatusCode(201);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


    }
}
