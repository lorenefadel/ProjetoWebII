using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class ProfessorModel
    {
        private sistema_facensContext _context;

        public ProfessorModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do professor")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF do professor")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o Perfil do professor")]
        public string Perfil { get; set; }

        [Required(ErrorMessage = "Informe a Titulação do professor")]
        public string Titulacao { get; set; }

        [Required(ErrorMessage = "Informe o Email do professor")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }

        public string Senha { get; set; }

        public List<ProfessorModel> ListarProfessores()
        {
            List<ProfessorModel> lista = new List<ProfessorModel>();
            ProfessorModel item;
            List<Professor> dt = _context.Professor.OrderBy(t => t.Nome).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new ProfessorModel
                {
                    Id = dt.ElementAt(i).IdProfessor.ToString(),
                    Nome = dt.ElementAt(i).Nome.ToString(),
                    CPF = dt.ElementAt(i).Cpf.ToString(),
                    Perfil = dt.ElementAt(i).Perfil.ToString(),
                    Senha = dt.ElementAt(i).Senha.ToString(),
                    Titulacao = dt.ElementAt(i).Titulacao.ToString(),
                    Email = dt.ElementAt(i).Email.ToString()
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
                Professor professorToEdit = _context.Professor.FirstOrDefault(t => t.IdProfessor == Convert.ToInt32(Id));

                professorToEdit.Nome = Nome;
                professorToEdit.Perfil = Perfil;
                professorToEdit.Titulacao = Titulacao;
                professorToEdit.Email = Email;
                professorToEdit.Cpf = CPF;

                _context.Entry(professorToEdit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _context.Professor.Add(new Professor()
                {
                    Cpf = CPF,
                    Email = Email,
                    Nome = Nome,
                    Perfil = Perfil,
                    Senha = "123",
                    Titulacao = Titulacao
                });
            }

            _context.SaveChanges();
        }

        // delete
        public void Excluir(int id)
        {
            Professor professorToRemove = _context.Professor.FirstOrDefault(t => t.IdProfessor == id);

            _context.Professor.Remove(professorToRemove);
            _context.SaveChanges();
        }

        public ProfessorModel RetornarProfessor(int? id)
        {
            ProfessorModel item;
            Professor dt = _context.Professor.FirstOrDefault(t => t.IdProfessor == id);

            item = new ProfessorModel
            {
                Id = dt.IdProfessor.ToString(),
                Nome = dt.Nome.ToString(),
                CPF = dt.Cpf.ToString(),
                Perfil = dt.Perfil.ToString(),
                Senha = dt.Senha.ToString(),
                Titulacao = dt.Titulacao.ToString(),
                Email = dt.Email.ToString()
            };

            return item;
        }
    }
}