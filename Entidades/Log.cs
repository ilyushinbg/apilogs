﻿using System;

namespace APILogs.Entidades
{
    public class Log
    {
        public DateTime DataHora { get; set; }
        public string MensagemErro { get; set; }
        public string RastreioErro { get; set; }
        public string NomeMaquina { get; set; }
        public string NomeAplicacao { get; set; }
        public string Usuario { get; set; }
        
        public long Identificador { get; set; }

    }
}
