using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class DisciplinaHasProfessor
    {
        public int DisciplinaHasProfessorId { get; set; }
        public int DisciplinaIdDisciplina { get; set; }
        public int ProfessorIdProfessor { get; set; }

        public Disciplina DisciplinaIdDisciplinaNavigation { get; set; }
        public Professor ProfessorIdProfessorNavigation { get; set; }
    }
}
