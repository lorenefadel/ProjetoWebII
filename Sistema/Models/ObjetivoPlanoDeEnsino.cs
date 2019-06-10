using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class ObjetivoPlanoDeEnsino
    {
        public int IdObjetivoPlanoDeEnsino { get; set; }
        public int? IdPlanoDeEnsino { get; set; }
        public int? IdObjetivo { get; set; }

        public Objetivo IdObjetivoNavigation { get; set; }
        public PlanoDeEnsino IdPlanoDeEnsinoNavigation { get; set; }
    }
}
