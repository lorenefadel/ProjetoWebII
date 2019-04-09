using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class CompetênciaHasDisciplina
    {
        public int CompetênciaHasDisciplinaId { get; set; }
        public int CompetênciaIdCompetência { get; set; }
        public int DisciplinaIdDisciplina { get; set; }

        public Competência CompetênciaIdCompetênciaNavigation { get; set; }
        public Disciplina DisciplinaIdDisciplinaNavigation { get; set; }
    }
}
