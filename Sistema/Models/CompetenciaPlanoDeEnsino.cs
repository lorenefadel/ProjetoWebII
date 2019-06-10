using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class CompetenciaPlanoDeEnsino
    {
        public int IdCompetenciaPlanoDeEnsino { get; set; }
        public int? IdPlanoDeEnsino { get; set; }
        public int? IdCompetencia { get; set; }

        public Competência IdCompetenciaNavigation { get; set; }
        public PlanoDeEnsino IdPlanoDeEnsinoNavigation { get; set; }
    }
}
