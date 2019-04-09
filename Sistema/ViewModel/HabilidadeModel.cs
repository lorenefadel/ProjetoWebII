using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class HabilidadeModel
    {
        private sistema_facensContext _context;

        public HabilidadeModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do professor")]
        public string Descricao { get; set; }

        public String IdDisciplina { get; set; }

        public List<HabilidadeModel> ListarHabilidades()
        {
            List<HabilidadeModel> lista = new List<HabilidadeModel>();
            HabilidadeModel item;
            List<Habilidade> dt = _context.Habilidade.OrderBy(t => t.Descricao).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new HabilidadeModel
                {
                    Id = dt.ElementAt(i).IdHabilidade.ToString(),
                    Descricao = dt.ElementAt(i).Descricao.ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        // insert ou update
        public void Gravar()
        {
            Habilidade habilidade;

            if (Id != null)
            {
                habilidade = _context.Habilidade.FirstOrDefault(t => t.IdHabilidade == Convert.ToInt32(Id));

                habilidade.Descricao = Descricao;

                _context.Entry(habilidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {

                habilidade = new Habilidade()
                {
                    Descricao = Descricao
                };

                _context.Habilidade.Add(habilidade);
            }

            _context.SaveChanges();

            _context.HabilidadeHasDisciplina.Add(new HabilidadeHasDisciplina()
            {
                HabilidadeIdHabilidade = habilidade.IdHabilidade,
                DisciplinaIdDisciplina = Convert.ToInt32(IdDisciplina)
            });

            _context.SaveChanges();
        }
        
        // delete
        public void Excluir(int id)
        {
            List<HabilidadeHasDisciplina> habilidades = _context.HabilidadeHasDisciplina.Where(t => t.HabilidadeIdHabilidade == id).ToList();
            _context.HabilidadeHasDisciplina.RemoveRange(habilidades);
            _context.SaveChanges();

            Habilidade habilidadeToRemove = _context.Habilidade.FirstOrDefault(t => t.IdHabilidade == id);

            _context.Habilidade.Remove(habilidadeToRemove);
            _context.SaveChanges();
        }

        public HabilidadeModel RetornarHabilidade(int? id)
        {
            HabilidadeModel item;
            Habilidade dt = _context.Habilidade.FirstOrDefault(t => t.IdHabilidade == id);

            item = new HabilidadeModel
            {
                Id = dt.IdHabilidade.ToString(),
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
