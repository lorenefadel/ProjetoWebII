using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Professor
    {
        public Professor()
        {
            DisciplinaHasProfessor = new HashSet<DisciplinaHasProfessor>();
        }

        public int IdProfessor { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Perfil { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Titulacao { get; set; }

        public ICollection<DisciplinaHasProfessor> DisciplinaHasProfessor { get; set; }
    }
}
