using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class CompetenciaModel
    {
        private sistema_facensContext _context;

        public CompetenciaModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição da Competência")]
        public string Descricao { get; set; }

        public string IdDisciplina { get; set; }

        public List<CompetenciaModel> ListarCompetencias()
        {
            List<CompetenciaModel> lista = new List<CompetenciaModel>();

            CompetenciaModel item;
            List<Competência> dt = _context.Competência.OrderBy(t => t.Descricao).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new CompetenciaModel
                {
                    Id = dt.ElementAt(i).IdCompetência.ToString(),
                    Descricao = dt.ElementAt(i).Descricao.ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        // insert ou update
        public void Gravar()
        {
            Competência competencia;

            if (Id != null)
            {
                competencia = _context.Competência.FirstOrDefault(t => t.IdCompetência == Convert.ToInt32(Id));

                competencia.Descricao = Descricao;

                _context.Entry(competencia).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                competencia = new Competência()
                {
                    Descricao = Descricao
                };

                _context.Competência.Add(competencia);
            }

            _context.SaveChanges();

            List<CompetênciaHasDisciplina> disciplinas = _context.CompetênciaHasDisciplina.Where(t => t.CompetênciaIdCompetência == competencia.IdCompetência).ToList();

            if (!disciplinas.Any(t => t.DisciplinaIdDisciplina == Convert.ToInt32(IdDisciplina)))
            {
                _context.CompetênciaHasDisciplina.Add(new CompetênciaHasDisciplina()
                {
                    CompetênciaIdCompetência = competencia.IdCompetência,
                    DisciplinaIdDisciplina = Convert.ToInt32(IdDisciplina)
                });
            }

            _context.CompetênciaHasDisciplina.RemoveRange(disciplinas.Where(s => s.DisciplinaIdDisciplina != Convert.ToInt32(IdDisciplina)));

            _context.SaveChanges();
        }
        
        // delete
        public void Excluir(int id)
        {
            List<CompetênciaHasDisciplina> disciplinas = _context.CompetênciaHasDisciplina.Where(t => t.CompetênciaIdCompetência == id).ToList();
            _context.CompetênciaHasDisciplina.RemoveRange(disciplinas);
            _context.SaveChanges();

            Competência competenciaToRemove = _context.Competência.FirstOrDefault(t => t.IdCompetência == id);

            _context.Competência.Remove(competenciaToRemove);
            _context.SaveChanges();
        }

        public CompetenciaModel RetornarCompetencia(int? id)
        {
            CompetenciaModel item;
            Competência dt = _context.Competência.FirstOrDefault(t => t.IdCompetência == id);

            item = new CompetenciaModel
            {
                Id = dt.IdCompetência.ToString(),
                Descricao = dt.Descricao.ToString()
            };

            return item;
        }

        public List<DisciplinaModel> GetDisciplinas()
        {
            List<DisciplinaModel> lista = new List<DisciplinaModel>();

            DisciplinaModel item;
            List<Disciplina> dt = _context.Disciplina.OrderBy(t => t.Descricao).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new DisciplinaModel
                {
                    Id = dt.ElementAt(i).IdDisciplina.ToString(),
                    Descricao = dt.ElementAt(i).Descricao.ToString()
                };
                lista.Add(item);
            }
            return lista;
        }
    }
}