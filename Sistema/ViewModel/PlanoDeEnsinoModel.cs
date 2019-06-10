using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sistema.Uteis;

namespace Sistema.Models
{
    public class PlanoDeEnsinoModel
    {
        private sistema_facensContext _context;

        public PlanoDeEnsinoModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);

            CompetenciaPlanoDeEnsino = new List<CompetenciaPlanoDeEnsino>();
            HabilidadePlanoDeEnsino = new List<HabilidadePlanoDeEnsino>();
            Livro = new List<Livro>();
            MembroNde = new List<MembroNde>();
            ObjetivoPlanoDeEnsino = new List<ObjetivoPlanoDeEnsino>();
        }

        public int IdPlanoDeEnsino { get; set; }
        public int? IdCurso { get; set; }
        public int? IdDisciplina { get; set; }
        public int CargaHorariaTeorica { get; set; }
        public int CargaHorariaPratica { get; set; }
        public int? IdProfessor { get; set; }
        public int? IdCoordenador { get; set; }
        public DateTime DateAtualizacao { get; set; }
        public DateTime? DateValidacaoNde { get; set; }

        public string nomeCurso { get; set; }
        public string nomeDisciplina { get; set; }
        public string nomeProfessor { get; set; }
        public string nomeCoordenador { get; set; }

        public int CargaHorariaTotal {
            get
            {
                return CargaHorariaPratica + CargaHorariaTeorica;
            }
        }

        public string Ementa { get; set; }
        public string ConteudoProgramaticoM1 { get; set; }
        public string ConteudoProgramaticoM2 { get; set; }
        public string MetodologiaDeEnsino { get; set; }
        public string Avaliacao { get; set; }

        public ICollection<CompetenciaPlanoDeEnsino> CompetenciaPlanoDeEnsino { get; set; }
        public ICollection<HabilidadePlanoDeEnsino> HabilidadePlanoDeEnsino { get; set; }
        public ICollection<Livro> Livro { get; set; }
        public ICollection<MembroNde> MembroNde { get; set; }
        public ICollection<ObjetivoPlanoDeEnsino> ObjetivoPlanoDeEnsino { get; set; }

        public List<PlanoDeEnsinoModel> ListarPlanosDeEnsino()
        {
            List<PlanoDeEnsinoModel> lista = new List<PlanoDeEnsinoModel>();
            PlanoDeEnsinoModel item;
            List<PlanoDeEnsino> dt = _context.PlanoDeEnsino.Include(s => s.IdCursoNavigation).Include(s => s.IdDisciplinaNavigation).OrderBy(t => t.IdPlanoDeEnsino).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new PlanoDeEnsinoModel
                {
                    IdPlanoDeEnsino = dt.ElementAt(i).IdPlanoDeEnsino,
                    nomeCurso = dt.ElementAt(i).IdCursoNavigation.Descricao,
                    nomeDisciplina = dt.ElementAt(i).IdDisciplinaNavigation.Descricao
                };

                lista.Add(item);
            }

            return lista;
        }

        // insert ou update
        public void Gravar(
            List<int> objetivos,
            List<int> competencias,
            List<int> habilidades,
            List<string> basica,
            List<string> complementar,
            List<string> nde
        )
        {
            PlanoDeEnsino planoDeEnsino = new PlanoDeEnsino()
            {
                MetodologiaDeEnsino = MetodologiaDeEnsino,
                IdCoordenador = IdCoordenador,
                IdCurso = IdCurso,
                Avaliacao = Avaliacao,
                CargaHorariaPratica = CargaHorariaPratica,
                CargaHorariaTeorica = CargaHorariaTeorica,
                ConteudoProgramaticoM1 = ConteudoProgramaticoM1,
                ConteudoProgramaticoM2 = ConteudoProgramaticoM2,
                DateAtualizacao = DateAtualizacao,
                DateValidacaoNde = DateValidacaoNde,
                Ementa = Ementa,
                IdDisciplina = IdDisciplina,
                IdProfessor = IdProfessor
            };

            _context.PlanoDeEnsino.Add(planoDeEnsino);
            _context.SaveChanges();

            foreach (var item in objetivos)
            {
                _context.ObjetivoPlanoDeEnsino.Add(new ObjetivoPlanoDeEnsino()
                {
                    IdObjetivo = item,
                    IdPlanoDeEnsino = planoDeEnsino.IdPlanoDeEnsino
                });
            }

            foreach (var item in habilidades)
            {
                _context.HabilidadePlanoDeEnsino.Add(new HabilidadePlanoDeEnsino()
                {
                    IdHabilidade = item,
                    IdPlanoDeEnsino = planoDeEnsino.IdPlanoDeEnsino
                });
            }

            foreach (var item in competencias)
            {
                _context.CompetenciaPlanoDeEnsino.Add(new CompetenciaPlanoDeEnsino()
                {
                    IdCompetencia = item,
                    IdPlanoDeEnsino = planoDeEnsino.IdPlanoDeEnsino
                });
            }

            foreach (var item in basica)
            {
                _context.Livro.Add(new Livro()
                {
                    BibliografiaBasica = true,
                    NomeLivro = item,
                    IdPlanoDeEnsino = planoDeEnsino.IdPlanoDeEnsino
                });
            }

            foreach (var item in complementar)
            {
                _context.Livro.Add(new Livro()
                {
                    BibliografiaBasica = false,
                    NomeLivro = item,
                    IdPlanoDeEnsino = planoDeEnsino.IdPlanoDeEnsino
                });
            }

            foreach (var item in nde)
            {
                _context.MembroNde.Add(new MembroNde()
                {
                    Nome = item,
                    IdPlanoDeEnsino = planoDeEnsino.IdPlanoDeEnsino
                });
            }

            _context.SaveChanges();
        }

        // delete
        public void Excluir(int id)
        {
            var objetivos = _context.ObjetivoPlanoDeEnsino.Where(t => t.IdPlanoDeEnsino == id).ToList();
            _context.ObjetivoPlanoDeEnsino.RemoveRange(objetivos);
            _context.SaveChanges();

            var habilidades = _context.HabilidadePlanoDeEnsino.Where(t => t.IdPlanoDeEnsino == id).ToList();
            _context.HabilidadePlanoDeEnsino.RemoveRange(habilidades);
            _context.SaveChanges();

            var competencias = _context.CompetenciaPlanoDeEnsino.Where(t => t.IdPlanoDeEnsino == id).ToList();
            _context.CompetenciaPlanoDeEnsino.RemoveRange(competencias);
            _context.SaveChanges();

            var livros = _context.Livro.Where(t => t.IdPlanoDeEnsino == id).ToList();
            _context.Livro.RemoveRange(livros);
            _context.SaveChanges();

            var nde = _context.MembroNde.Where(t => t.IdPlanoDeEnsino == id).ToList();
            _context.MembroNde.RemoveRange(nde);
            _context.SaveChanges();

            PlanoDeEnsino planoDeEnsino = _context.PlanoDeEnsino.FirstOrDefault(t => t.IdPlanoDeEnsino == id);

            _context.PlanoDeEnsino.Remove(planoDeEnsino);
            _context.SaveChanges();
        }

        public PlanoDeEnsinoModel RetornarPlanoDeEnsino(int? id)
        {
            PlanoDeEnsino dt = _context.PlanoDeEnsino
                .Include(s => s.MembroNde)
                .Include(s => s.Livro)
                .Include("CompetenciaPlanoDeEnsino.IdCompetenciaNavigation")
                .Include("HabilidadePlanoDeEnsino.IdHabilidadeNavigation")
                .Include("ObjetivoPlanoDeEnsino.IdObjetivoNavigation")
                .Include(s => s.IdCursoNavigation.CoordenadorIdCoordenadorNavigation)
                .Include(s => s.IdDisciplinaNavigation)
                .Include(s => s.IdProfessorNavigation)
                .FirstOrDefault(t => t.IdPlanoDeEnsino == id);

            return new PlanoDeEnsinoModel
            {
                IdPlanoDeEnsino = dt.IdPlanoDeEnsino,
                nomeCurso = dt.IdCursoNavigation.Descricao,
                nomeDisciplina = dt.IdDisciplinaNavigation.Descricao,
                nomeCoordenador = dt.IdCursoNavigation.CoordenadorIdCoordenadorNavigation.Nome,
                nomeProfessor = dt.IdProfessorNavigation.Nome,
                Avaliacao = dt.Avaliacao,
                CargaHorariaPratica = dt.CargaHorariaPratica.Value,
                CargaHorariaTeorica = dt.CargaHorariaTeorica.Value,
                ConteudoProgramaticoM1 = dt.ConteudoProgramaticoM1,
                ConteudoProgramaticoM2 = dt.ConteudoProgramaticoM2,
                DateAtualizacao = dt.DateAtualizacao,
                DateValidacaoNde = dt.DateValidacaoNde,
                Ementa = dt.Ementa,
                IdCoordenador = dt.IdCoordenador,
                IdCurso = dt.IdCurso,
                IdDisciplina = dt.IdDisciplina,
                IdProfessor = dt.IdProfessor,
                MetodologiaDeEnsino = dt.MetodologiaDeEnsino,
                ObjetivoPlanoDeEnsino = dt.ObjetivoPlanoDeEnsino,
                MembroNde = dt.MembroNde,
                HabilidadePlanoDeEnsino = dt.HabilidadePlanoDeEnsino,
                CompetenciaPlanoDeEnsino = dt.CompetenciaPlanoDeEnsino,
                Livro = dt.Livro
            };
        }

        public void UpdateFields()
        {
            DisciplinaModel disciplina = new DisciplinaModel().RetornarDisciplina(IdDisciplina);
            ProfessorModel professor = new ProfessorModel().RetornarProfessor(IdProfessor);
            Curso curso = _context.DisciplinaHasCurso.Where(s => s.DisciplinaIdDisciplina == IdDisciplina).Select(s => s.CursoIdCursoNavigation).Include(s => s.CoordenadorIdCoordenadorNavigation).FirstOrDefault();

            // não tenho duas cargas horarias no cadastro de disciplina
            CargaHorariaTeorica = CargaHorariaPratica = disciplina.CargaHoraria;
            nomeDisciplina = disciplina.Descricao;
            nomeProfessor = professor.Nome;
            nomeCurso = curso.Descricao;
            nomeCoordenador = curso.CoordenadorIdCoordenadorNavigation.Nome;

            IdCurso = curso.IdCurso;
            IdCoordenador = curso.CoordenadorIdCoordenador;
            DateAtualizacao = DateTime.Now;
        }
    }
}