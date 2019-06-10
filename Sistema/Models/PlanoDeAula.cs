using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class PlanoDeAula
    {
        public PlanoDeAula()
        {
            AvaliacaoPlanoDeAula = new HashSet<AvaliacaoPlanoDeAula>();
            ConteudoPlanoDeAula = new HashSet<ConteudoPlanoDeAula>();
            Livro = new HashSet<Livro>();
        }

        public int IdPlanoDeAula { get; set; }
        public int? IdCurso { get; set; }
        public int? IdDisciplina { get; set; }
        public int? IdTurma { get; set; }
        public int? CargaHorariaTeorica { get; set; }
        public int? CargaHorariaPratica { get; set; }
        public int? IdProfessor { get; set; }
        public int? IdCoordenador { get; set; }
        public int? Semestre { get; set; }
        public int? Ano { get; set; }

        public Coordenador IdCoordenadorNavigation { get; set; }
        public Curso IdCursoNavigation { get; set; }
        public Disciplina IdDisciplinaNavigation { get; set; }
        public Professor IdProfessorNavigation { get; set; }
        public Turma IdTurmaNavigation { get; set; }
        public ICollection<AvaliacaoPlanoDeAula> AvaliacaoPlanoDeAula { get; set; }
        public ICollection<ConteudoPlanoDeAula> ConteudoPlanoDeAula { get; set; }
        public ICollection<Livro> Livro { get; set; }
    }
}
