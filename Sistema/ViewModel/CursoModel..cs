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
    public class CursoModel
    {
        private sistema_facensContext _context;

        public CursoModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição do Curso")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o Coordenador do Curso")]
        public int IdCoordenador { get; set; }

        public string IdDisciplina { get; set; }

        public string NomeCoordenador { get; set; }

        public List<CursoModel> ListarCursos()
        {
            List<CursoModel> lista = new List<CursoModel>();

            CursoModel item;
            List<Curso> dt = _context.Curso.Include(p => p.CoordenadorIdCoordenadorNavigation).OrderBy(t => t.Descricao).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new CursoModel
                {
                    Id = dt.ElementAt(i).IdCurso.ToString(),
                    Descricao = dt.ElementAt(i).Descricao.ToString(),
                    NomeCoordenador = dt.ElementAt(i).CoordenadorIdCoordenadorNavigation.Nome
                };
                lista.Add(item);
            }
            return lista;
        }

        // insert ou update
        public void Gravar()
        {
            Curso curso;

            if (Id != null)
            {
                curso = _context.Curso.FirstOrDefault(t => t.IdCurso == Convert.ToInt32(Id));

                curso.Descricao = Descricao;


                _context.Entry(curso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                curso = new Curso()
                {
                    Descricao = Descricao,
                    CoordenadorIdCoordenador = IdCoordenador

                };

                _context.Curso.Add(curso);
            }

            _context.SaveChanges();
            
        }
        
        // delete
        public void Excluir(int id)
        {
            Curso cursoToRemove = _context.Curso.FirstOrDefault(t => t.IdCurso == id);

            _context.Curso.Remove(cursoToRemove);
            _context.SaveChanges();
        }

        public CursoModel RetornarCurso(int? id)
        {
            CursoModel item;
            Curso dt = _context.Curso.FirstOrDefault(t => t.IdCurso == id);

            item = new CursoModel
            {
                Id = dt.IdCurso.ToString(),
                Descricao = dt.Descricao.ToString()
            };

            return item;
        }

        public List<CoordenadorModel> GetCoordenadores()
        {
            List<CoordenadorModel> lista = new List<CoordenadorModel>();

            CoordenadorModel item;
            List<Coordenador> dt = _context.Coordenador.OrderBy(t => t.Nome).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new CoordenadorModel
                {
                    Id = dt.ElementAt(i).IdCoordenador.ToString(),
                    Nome = dt.ElementAt(i).Nome.ToString()
                };
                lista.Add(item);
            }
            return lista;
        }
    }
}