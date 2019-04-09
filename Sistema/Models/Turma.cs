﻿using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Turma
    {
        public Turma()
        {
            DisciplinaHasCurso = new HashSet<DisciplinaHasCurso>();
        }

        public int IdTurma { get; set; }
        public string Codigo { get; set; }

        public ICollection<DisciplinaHasCurso> DisciplinaHasCurso { get; set; }
    }
}
