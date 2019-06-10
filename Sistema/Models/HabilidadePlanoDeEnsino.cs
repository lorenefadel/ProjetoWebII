using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class HabilidadePlanoDeEnsino
    {
        public int IdHabilidadePlanoDeEnsino { get; set; }
        public int? IdPlanoDeEnsino { get; set; }
        public int? IdHabilidade { get; set; }

        public Habilidade IdHabilidadeNavigation { get; set; }
        public PlanoDeEnsino IdPlanoDeEnsinoNavigation { get; set; }
    }
}
