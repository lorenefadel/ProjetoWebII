using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class ConteudoPlanoDeAula
    {
        public int IdConteudoAula { get; set; }
        public int? IdPlanoDeAula { get; set; }
        public string Semana { get; set; }
        public DateTime? DataConteudo { get; set; }
        public string Bibliografia { get; set; }
        public string Descricao { get; set; }

        public PlanoDeAula IdPlanoDeAulaNavigation { get; set; }
    }
}
