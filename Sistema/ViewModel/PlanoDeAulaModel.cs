using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sistema.Uteis;

namespace Sistema.Models
{
    public class PlanoDeAulaModel
    {
        private sistema_facensContext _context;

        public PlanoDeAulaModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);
            Livro = new List<Livro>();
            Conteudo = new List<ConteudoPlanoDeAula>();
            Notas = new List<AvaliacaoPlanoDeAula>();
        }

        public int IdPlanoDeAula { get; set; }
        public int? IdCurso { get; set; }
        public int? IdDisciplina { get; set; }
        public int? IdTurma { get; set; }
        public int CargaHorariaTeorica { get; set; }
        public int CargaHorariaPratica { get; set; }
        public int? IdProfessor { get; set; }
        public int? IdCoordenador { get; set; }
        public int Ano { get; set; }
        public int Semestre { get; set; }

        public string nomeCurso { get; set; }
        public string nomeDisciplina { get; set; }
        public string nomeProfessor { get; set; }
        public string emailProfessor { get; set; }
        public string nomeCoordenador { get; set; }
        public string nomeTurma { get; set; }

        public int CargaHorariaTotal {
            get
            {
                return CargaHorariaPratica + CargaHorariaTeorica;
            }
        }

        public ICollection<Livro> Livro { get; set; }
        public ICollection<ConteudoPlanoDeAula> Conteudo { get; set; }
        public ICollection<AvaliacaoPlanoDeAula> Notas { get; set; }

        public List<PlanoDeAulaModel> ListarPlanosDeAula()
        {
            List<PlanoDeAulaModel> lista = new List<PlanoDeAulaModel>();
            PlanoDeAulaModel item;
            List<PlanoDeAula> dt = _context.PlanoDeAula.Include(s => s.IdCursoNavigation).Include(s => s.IdDisciplinaNavigation).OrderBy(t => t.IdPlanoDeAula).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new PlanoDeAulaModel
                {
                    IdPlanoDeAula = dt.ElementAt(i).IdPlanoDeAula,
                    nomeCurso = dt.ElementAt(i).IdCursoNavigation.Descricao,
                    nomeDisciplina = dt.ElementAt(i).IdDisciplinaNavigation.Descricao,
                    Semestre = dt.ElementAt(i).Semestre.Value,
                    Ano = dt.ElementAt(i).Ano.Value
                };

                lista.Add(item);
            }

            return lista;
        }

        // insert ou update
        public void Gravar(
            List<ConteudoPlanoDeAula> conteudo,
            List<string> basica,
            List<string> complementar,
            List<AvaliacaoPlanoDeAula> notas
        )
        {
            PlanoDeAula planoDeAula = new PlanoDeAula()
            {
                IdCoordenador = IdCoordenador,
                IdCurso = IdCurso,
                CargaHorariaPratica = CargaHorariaPratica,
                CargaHorariaTeorica = CargaHorariaTeorica,
                IdDisciplina = IdDisciplina,
                IdProfessor = IdProfessor,
                Ano = Ano,
                Semestre = Semestre,
                IdTurma = IdTurma,
                ConteudoPlanoDeAula = conteudo,
                AvaliacaoPlanoDeAula = notas
            };

            _context.PlanoDeAula.Add(planoDeAula);
            _context.SaveChanges();

            foreach (var item in basica)
            {
                _context.Livro.Add(new Livro()
                {
                    BibliografiaBasica = true,
                    NomeLivro = item,
                    IdPlanoDeAula = planoDeAula.IdPlanoDeAula
                });
            }

            foreach (var item in complementar)
            {
                _context.Livro.Add(new Livro()
                {
                    BibliografiaBasica = false,
                    NomeLivro = item,
                    IdPlanoDeAula = planoDeAula.IdPlanoDeAula
                });
            }

            _context.SaveChanges();
        }

        // delete
        public void Excluir(int id)
        {
            var livros = _context.Livro.Where(t => t.IdPlanoDeAula == id).ToList();
            _context.Livro.RemoveRange(livros);
            _context.SaveChanges();

            var conteudos = _context.ConteudoPlanoDeAula.Where(t => t.IdPlanoDeAula == id).ToList();
            _context.ConteudoPlanoDeAula.RemoveRange(conteudos);
            _context.SaveChanges();

            var AvaliacaoPlanoDeAula = _context.AvaliacaoPlanoDeAula.Where(t => t.IdPlanoDeAula == id).ToList();
            _context.AvaliacaoPlanoDeAula.RemoveRange(AvaliacaoPlanoDeAula);
            _context.SaveChanges();

            PlanoDeAula planoDeAula = _context.PlanoDeAula.FirstOrDefault(t => t.IdPlanoDeAula == id);

            _context.PlanoDeAula.Remove(planoDeAula);
            _context.SaveChanges();
        }

        public PlanoDeAulaModel RetornarPlanoDeAula(int? id)
        {
            PlanoDeAula dt = _context.PlanoDeAula
                .Include(s => s.Livro)
                .Include(s => s.IdCursoNavigation.CoordenadorIdCoordenadorNavigation)
                .Include(s => s.IdDisciplinaNavigation)
                .Include(s => s.IdProfessorNavigation)
                .Include(s => s.IdTurmaNavigation)
                .Include(s => s.ConteudoPlanoDeAula)
                .Include(s => s.AvaliacaoPlanoDeAula)
                .FirstOrDefault(t => t.IdPlanoDeAula == id);

            return new PlanoDeAulaModel() {
                IdPlanoDeAula = dt.IdPlanoDeAula,
                Ano = dt.Ano.Value,
                Semestre = dt.Semestre.Value,
                CargaHorariaPratica = dt.CargaHorariaPratica.Value,
                CargaHorariaTeorica = dt.CargaHorariaTeorica.Value,
                Conteudo = dt.ConteudoPlanoDeAula,
                emailProfessor = dt.IdProfessorNavigation.Email,
                IdCoordenador = dt.IdCoordenador,
                IdCurso = dt.IdCurso,
                IdDisciplina = dt.IdDisciplina,
                IdProfessor = dt.IdProfessor,
                IdTurma = dt.IdTurma,
                Livro = dt.Livro,
                nomeCoordenador = dt.IdCoordenadorNavigation.Nome,
                nomeCurso = dt.IdCursoNavigation.Descricao,
                nomeDisciplina = dt.IdDisciplinaNavigation.Descricao,
                nomeProfessor = dt.IdProfessorNavigation.Nome,
                nomeTurma = dt.IdTurmaNavigation.Codigo,
                Notas = dt.AvaliacaoPlanoDeAula
            };
        }

        public void UpdateFields()
        {
            DisciplinaModel disciplina = new DisciplinaModel().RetornarDisciplina(IdDisciplina);

            Curso curso = _context.DisciplinaHasCurso.Where(s => s.DisciplinaIdDisciplina == IdDisciplina).Select(s => s.CursoIdCursoNavigation).Include(s => s.CoordenadorIdCoordenadorNavigation).FirstOrDefault();
            Turma turma = _context.DisciplinaHasCurso.Where(s => s.DisciplinaIdDisciplina == IdDisciplina).Select(s => s.TurmaIdTurmaNavigation).FirstOrDefault();
            Professor professor = _context.DisciplinaHasProfessor.Where(s => s.DisciplinaIdDisciplina == IdDisciplina).Select(s => s.ProfessorIdProfessorNavigation).FirstOrDefault();
           
            // não tenho duas cargas horarias no cadastro de disciplina
            CargaHorariaTeorica = CargaHorariaPratica = disciplina.CargaHoraria;
            nomeDisciplina = disciplina.Descricao;
            nomeProfessor = professor.Nome;
            emailProfessor = professor.Email;
            nomeCurso = curso.Descricao;
            nomeCoordenador = curso.CoordenadorIdCoordenadorNavigation.Nome;
            nomeTurma = turma.Codigo;

            IdProfessor = professor.IdProfessor;
            IdTurma = turma.IdTurma;
            IdCurso = curso.IdCurso;
            IdCoordenador = curso.CoordenadorIdCoordenador;
        }
    }
}