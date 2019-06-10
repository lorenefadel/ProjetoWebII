using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class ObjetivoModel
    {
        private sistema_facensContext _context;

        public ObjetivoModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do coordenador")]
        public string Descricao { get; set; }

        public String IdDisciplina { get; set; }

        public List<ObjetivoModel> ListarObjetivos()
        {
            List<ObjetivoModel> lista = new List<ObjetivoModel>();

            ObjetivoModel item;
            List<Objetivo> dt = _context.Objetivo.OrderBy(t => t.Descricao).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new ObjetivoModel
                {
                    Id = dt.ElementAt(i).IdObjetivo.ToString(),
                    Descricao = dt.ElementAt(i).Descricao.ToString(),
                    IdDisciplina = _context.ObjetivoHasDisciplina.FirstOrDefault(s => s.ObjetivoIdObjetivo == dt.ElementAt(i).IdObjetivo)?.DisciplinaIdDisciplina.ToString()
                };

                lista.Add(item);
            }
            return lista;
        }

        // insert ou update
        public void Gravar()
        {
            Objetivo objetivo;

            if (Id != null)
            {
                objetivo = _context.Objetivo.FirstOrDefault(t => t.IdObjetivo == Convert.ToInt32(Id));

                objetivo.Descricao = Descricao;

                _context.Entry(objetivo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {

                objetivo = new Objetivo()
                {
                    Descricao = Descricao
                };

                _context.Objetivo.Add(objetivo);
            }

            _context.SaveChanges();

            _context.ObjetivoHasDisciplina.Add(new ObjetivoHasDisciplina()
            {
                ObjetivoIdObjetivo = objetivo.IdObjetivo,
                DisciplinaIdDisciplina = Convert.ToInt32(IdDisciplina)
            });

            _context.SaveChanges();
        }

        // delete
        public void Excluir(int id)
        {
            List<ObjetivoHasDisciplina> objetivos = _context.ObjetivoHasDisciplina.Where(t => t.ObjetivoIdObjetivo == id).ToList();
            _context.ObjetivoHasDisciplina.RemoveRange(objetivos);
            _context.SaveChanges();

            Objetivo objetivoToRemove = _context.Objetivo.FirstOrDefault(t => t.IdObjetivo == id);

            _context.Objetivo.Remove(objetivoToRemove);
            _context.SaveChanges();
        }
        public ObjetivoModel RetornarObjetivo(int? id)
        {
            ObjetivoModel item;
            Objetivo dt = _context.Objetivo.FirstOrDefault(t => t.IdObjetivo == id);

            item = new ObjetivoModel
            {
                Id = dt.IdObjetivo.ToString(),
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
