using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class HabilidadeHasDisciplina
    {
        public int HabilidadeHasDisciplinaId { get; set; }
        public int HabilidadeIdHabilidade { get; set; }
        public int DisciplinaIdDisciplina { get; set; }

        public Disciplina DisciplinaIdDisciplinaNavigation { get; set; }
        public Habilidade HabilidadeIdHabilidadeNavigation { get; set; }
    }
}
