using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class ObjetivoHasDisciplina
    {
        public int ObjetivoHasDisciplinaId { get; set; }
        public int ObjetivoIdObjetivo { get; set; }
        public int DisciplinaIdDisciplina { get; set; }

        public Disciplina DisciplinaIdDisciplinaNavigation { get; set; }
        public Objetivo ObjetivoIdObjetivoNavigation { get; set; }
    }
}
