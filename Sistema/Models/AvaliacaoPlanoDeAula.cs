using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class AvaliacaoPlanoDeAula
    {
        public int IdAvaliacaoPlanoAula { get; set; }
        public int? IdPlanoDeAula { get; set; }
        public string Atividade { get; set; }
        public string Descricao { get; set; }
        public string Peso { get; set; }

        public PlanoDeAula IdPlanoDeAulaNavigation { get; set; }
    }
}
