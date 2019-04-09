using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema.Uteis;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class CoordenadorModel
    {
        private sistema_facensContext _context;

        public CoordenadorModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome do coordenador")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF do coordenador")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o Perfil do coordenador")]
        public string Perfil { get; set; }

        [Required(ErrorMessage = "Informe a Titulação do coordenador")]
        public string Titulacao { get; set; }

        [Required(ErrorMessage = "Informe o Email do coordenador")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }

        public string Senha { get; set; }

        public List<CoordenadorModel> ListarCoordenadores()
        {
            List<CoordenadorModel> lista = new List<CoordenadorModel>();
            CoordenadorModel item;
            List<Coordenador> dt = _context.Coordenador.OrderBy(t => t.Nome).ToList();

            for (int i = 0; i < dt.Count; i++)
            {
                item = new CoordenadorModel
                {
                    Id = dt.ElementAt(i).IdCoordenador.ToString(),
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
                Coordenador coordenadorToEdit = _context.Coordenador.FirstOrDefault(t => t.IdCoordenador == Convert.ToInt32(Id));

                coordenadorToEdit.Nome = Nome;
                coordenadorToEdit.Perfil = Perfil;
                coordenadorToEdit.Titulacao = Titulacao;
                coordenadorToEdit.Email = Email;
                coordenadorToEdit.Cpf = CPF;

                _context.Entry(coordenadorToEdit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _context.Coordenador.Add(new Coordenador()
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
            Coordenador coordenadorToRemove = _context.Coordenador.FirstOrDefault(t => t.IdCoordenador == id);

            _context.Coordenador.Remove(coordenadorToRemove);
            _context.SaveChanges();
        }

        public CoordenadorModel RetornarCoordenador(int? id)
        {
            CoordenadorModel item;
            Coordenador dt = _context.Coordenador.FirstOrDefault(t => t.IdCoordenador == id);

            item = new CoordenadorModel
            {
                Id = dt.IdCoordenador.ToString(),
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