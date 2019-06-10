using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class PlanoDeEnsino
    {
        public PlanoDeEnsino()
        {
            CompetenciaPlanoDeEnsino = new HashSet<CompetenciaPlanoDeEnsino>();
            HabilidadePlanoDeEnsino = new HashSet<HabilidadePlanoDeEnsino>();
            Livro = new HashSet<Livro>();
            MembroNde = new HashSet<MembroNde>();
            ObjetivoPlanoDeEnsino = new HashSet<ObjetivoPlanoDeEnsino>();
        }

        public int IdPlanoDeEnsino { get; set; }
        public int? IdCurso { get; set; }
        public int? IdDisciplina { get; set; }
        public int? CargaHorariaTeorica { get; set; }
        public int? CargaHorariaPratica { get; set; }
        public int? IdProfessor { get; set; }
        public int? IdCoordenador { get; set; }
        public DateTime DateAtualizacao { get; set; }
        public DateTime? DateValidacaoNde { get; set; }
        public string Ementa { get; set; }
        public string ConteudoProgramaticoM1 { get; set; }
        public string ConteudoProgramaticoM2 { get; set; }
        public string MetodologiaDeEnsino { get; set; }
        public string Avaliacao { get; set; }

        public Coordenador IdCoordenadorNavigation { get; set; }
        public Curso IdCursoNavigation { get; set; }
        public Disciplina IdDisciplinaNavigation { get; set; }
        public Professor IdProfessorNavigation { get; set; }
        public ICollection<CompetenciaPlanoDeEnsino> CompetenciaPlanoDeEnsino { get; set; }
        public ICollection<HabilidadePlanoDeEnsino> HabilidadePlanoDeEnsino { get; set; }
        public ICollection<Livro> Livro { get; set; }
        public ICollection<MembroNde> MembroNde { get; set; }
        public ICollection<ObjetivoPlanoDeEnsino> ObjetivoPlanoDeEnsino { get; set; }
    }
}
