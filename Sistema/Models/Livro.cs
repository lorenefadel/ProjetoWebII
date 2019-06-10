using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Livro
    {
        public int IdLivro { get; set; }
        public int? IdPlanoDeEnsino { get; set; }
        public string NomeLivro { get; set; }
        public bool BibliografiaBasica { get; set; }
        public int? IdPlanoDeAula { get; set; }

        public PlanoDeAula IdPlanoDeAulaNavigation { get; set; }
        public PlanoDeEnsino IdPlanoDeEnsinoNavigation { get; set; }
    }
}
