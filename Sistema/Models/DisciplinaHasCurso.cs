using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class DisciplinaHasCurso
    {
        public int DisciplinaHasCursoId { get; set; }
        public int DisciplinaIdDisciplina { get; set; }
        public int CursoIdCurso { get; set; }
        public int TurmaIdTurma { get; set; }

        public Curso CursoIdCursoNavigation { get; set; }
        public Disciplina DisciplinaIdDisciplinaNavigation { get; set; }
        public Turma TurmaIdTurmaNavigation { get; set; }
    }
}
