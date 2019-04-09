using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Sistema.Models
{
    public class DisciplinaModel
    {
        private sistema_facensContext _context;

        public DisciplinaModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Professor")]
        public String IdProfessor { get; set; }

        [Required(ErrorMessage = "Informe o Curso")]
        public String IdCurso { get; set; }

        [Required(ErrorMessage = "Informe a Turma")]
        public String IdTurma { get; set; }

        [Required(ErrorMessage = "Informe o Nome do professor")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o CPF do professor")]
        public int CargaHoraria { get; set; }

       public List<DisciplinaModel> ListarDisciplinas()
        {
            List<DisciplinaModel> lista = new List<DisciplinaModel>();
            DisciplinaModel item;
            List<Disciplina> dt = _context.Disciplina.OrderBy(t => t.Descricao).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new DisciplinaModel
                {
                    Id = dt.ElementAt(i).IdDisciplina.ToString(),
                    Descricao = dt.ElementAt(i).Descricao.ToString(),
                    CargaHoraria = dt.ElementAt(i).CargaHoraria
                };
                lista.Add(item);
            }
            return lista;
        }

        // insert ou update
        public void Gravar()
        {
             Disciplina disciplina;

            if (Id != null)
            {
                disciplina = _context.Disciplina.FirstOrDefault(t => t.IdDisciplina == Convert.ToInt32(Id));

                disciplina.Descricao = Descricao;
                disciplina.CargaHoraria = CargaHoraria;

                _context.Entry(disciplina).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {

                disciplina = new Disciplina()
                {
                    Descricao = Descricao,
                    CargaHoraria = CargaHoraria
                };

                _context.Disciplina.Add(disciplina);
            }

            _context.SaveChanges();

            _context.DisciplinaHasProfessor.Add(new DisciplinaHasProfessor()
            {
                DisciplinaIdDisciplina = disciplina.IdDisciplina,
                ProfessorIdProfessor = Convert.ToInt32(IdProfessor)
            });

            _context.DisciplinaHasCurso.Add(new DisciplinaHasCurso()
            {
                DisciplinaIdDisciplina = disciplina.IdDisciplina,
                CursoIdCurso = Convert.ToInt32(IdCurso),
                TurmaIdTurma = Convert.ToInt32(IdTurma)
            });

            _context.SaveChanges();
         
        }
        
        // delete
        public void Excluir(int id)
        {
            List<DisciplinaHasProfessor> disciplinasP = _context.DisciplinaHasProfessor.Where(t => t.DisciplinaIdDisciplina == id).ToList();
            _context.DisciplinaHasProfessor.RemoveRange(disciplinasP);

            List<DisciplinaHasCurso> disciplinasC = _context.DisciplinaHasCurso.Where(t => t.DisciplinaIdDisciplina == id).ToList();
            _context.DisciplinaHasCurso.RemoveRange(disciplinasC);
            _context.SaveChanges();

            Disciplina disciplinaToRemove = _context.Disciplina.FirstOrDefault(t => t.IdDisciplina == id);

            _context.Disciplina.Remove(disciplinaToRemove);
            _context.SaveChanges();
        }

        public DisciplinaModel RetornarDisciplina(int? id)
        {
            DisciplinaModel item;
            Disciplina dt = _context.Disciplina.FirstOrDefault(t => t.IdDisciplina == id);

            item = new DisciplinaModel
            {
                Id = dt.IdDisciplina.ToString(),
                Descricao = dt.Descricao.ToString(),
                CargaHoraria = dt.CargaHoraria
            };

            return item;
        }

        public List<ProfessorModel> GetProfessores()
        {
            List<ProfessorModel> lista = new List<ProfessorModel>();

            ProfessorModel item;
            List<Professor> dt = _context.Professor.OrderBy(t => t.Nome).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new ProfessorModel
                {
                    Id = dt.ElementAt(i).IdProfessor.ToString(),
                    Nome = dt.ElementAt(i).Nome.ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        public List<CursoModel> GetCursos()
        {
            List<CursoModel> lista = new List<CursoModel>();

            CursoModel item;
            List<Curso> dt = _context.Curso.OrderBy(t => t.Descricao).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new CursoModel
                {
                    Id = dt.ElementAt(i).IdCurso.ToString(),
                    Descricao = dt.ElementAt(i).Descricao.ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        public List<TurmaModel> GetTurmas()
        {
            List<TurmaModel> lista = new List<TurmaModel>();

            TurmaModel item;
            List<Turma> dt = _context.Turma.OrderBy(t => t.IdTurma).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new TurmaModel
                {
                    Id = dt.ElementAt(i).IdTurma.ToString(),
                    Codigo = dt.ElementAt(i).Codigo.ToString()
                };
                lista.Add(item);
            }
            return lista;
        }
    }
}
