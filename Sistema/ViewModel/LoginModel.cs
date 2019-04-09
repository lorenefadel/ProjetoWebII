using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Sistema.Uteis;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class LoginModel
    {
        private sistema_facensContext _context;

        public LoginModel()
        {
            _context = new sistema_facensContext(ContextHelpers.options);
        }

        public string Id { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage="Informe o e-mail do usuário!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="O e-mail informado é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }

        public bool ValidarLogin()
        {
            Admin admin = _context.Admin.FirstOrDefault(t => t.Email == Email && t.Senha == Senha);
            Coordenador coordenador = _context.Coordenador.FirstOrDefault(t => t.Email == Email && t.Senha == Senha);
            Professor professor = _context.Professor.FirstOrDefault(t => t.Email == Email && t.Senha == Senha);

            if (admin != null)
            {
                Id = admin.IdAdmin.ToString();
                Nome = admin.Nome;
                return true;
            }

            if (coordenador != null)
            {
                Id = coordenador.IdCoordenador.ToString();
                Nome = coordenador.Nome;
                return true;
            }

            if (professor != null)
            {
                Id = professor.IdProfessor.ToString();
                Nome = professor.Nome;
                return true;
            }

            return false;

            string sql = $"SELECT idcoordenador, NOME FROM sistema_facens.coordenador WHERE EMAIL='{Email}' AND SENHA='{Senha}'";

            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);
            
            if (dt.Rows.Count ==1)
            {
                Id = dt.Rows[0]["idcoordenador"].ToString();
                Nome = dt.Rows[0]["nome"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
