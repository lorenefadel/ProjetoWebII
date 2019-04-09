using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Competência
    {
        public Competência()
        {
            CompetênciaHasDisciplina = new HashSet<CompetênciaHasDisciplina>();
        }

        public int IdCompetência { get; set; }
        public string Descricao { get; set; }

        public ICollection<CompetênciaHasDisciplina> CompetênciaHasDisciplina { get; set; }
    }
}
