using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Disciplina
    {
        public Disciplina()
        {
            CompetênciaHasDisciplina = new HashSet<CompetênciaHasDisciplina>();
            DisciplinaHasCurso = new HashSet<DisciplinaHasCurso>();
            DisciplinaHasProfessor = new HashSet<DisciplinaHasProfessor>();
            HabilidadeHasDisciplina = new HashSet<HabilidadeHasDisciplina>();
            ObjetivoHasDisciplina = new HashSet<ObjetivoHasDisciplina>();
            PlanoDeAula = new HashSet<PlanoDeAula>();
            PlanoDeEnsino = new HashSet<PlanoDeEnsino>();
        }

        public int IdDisciplina { get; set; }
        public string Descricao { get; set; }
        public int CargaHoraria { get; set; }

        public ICollection<CompetênciaHasDisciplina> CompetênciaHasDisciplina { get; set; }
        public ICollection<DisciplinaHasCurso> DisciplinaHasCurso { get; set; }
        public ICollection<DisciplinaHasProfessor> DisciplinaHasProfessor { get; set; }
        public ICollection<HabilidadeHasDisciplina> HabilidadeHasDisciplina { get; set; }
        public ICollection<ObjetivoHasDisciplina> ObjetivoHasDisciplina { get; set; }
        public ICollection<PlanoDeAula> PlanoDeAula { get; set; }
        public ICollection<PlanoDeEnsino> PlanoDeEnsino { get; set; }
    }
}
