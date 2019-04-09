using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class TurmaModel
    {
        private sistema_facensContext _context;

        public TurmaModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Código da turma")]
        public string Codigo { get; set; }

        public List<TurmaModel> ListarTurmas()
        {
            List<TurmaModel> lista = new List<TurmaModel>();

            TurmaModel item;
            List<Turma> dt = _context.Turma.OrderBy(t => t.Codigo).ToList();

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

        // insert ou update
        public void Gravar()
        {
            if (Id != null)
            {
                Turma turmaToEdit = _context.Turma.FirstOrDefault(t => t.IdTurma == Convert.ToInt32(Id));

                turmaToEdit.Codigo = Codigo;

                _context.Entry(turmaToEdit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _context.Turma.Add(new Turma()
                {
                    Codigo = Codigo
                });
            }

            _context.SaveChanges();
        }
        
        // delete
        public void Excluir(int id)
        {
            Turma turmaToRemove = _context.Turma.FirstOrDefault(t => t.IdTurma == id);

            _context.Turma.Remove(turmaToRemove);
            _context.SaveChanges();
        }

        public TurmaModel RetornarTurma(int? id)
        {
            TurmaModel item;
            Turma dt = _context.Turma.FirstOrDefault(t => t.IdTurma == id);

            item = new TurmaModel
            {
                Id = dt.IdTurma.ToString(),
                Codigo = dt.Codigo.ToString()
            };

            return item;
        }
    }
}
