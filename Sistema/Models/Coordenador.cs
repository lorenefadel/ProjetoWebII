using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Coordenador
    {
        public Coordenador()
        {
            Curso = new HashSet<Curso>();
            PlanoDeAula = new HashSet<PlanoDeAula>();
            PlanoDeEnsino = new HashSet<PlanoDeEnsino>();
        }

        public int IdCoordenador { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Perfil { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Titulacao { get; set; }

        public ICollection<Curso> Curso { get; set; }
        public ICollection<PlanoDeAula> PlanoDeAula { get; set; }
        public ICollection<PlanoDeEnsino> PlanoDeEnsino { get; set; }
    }
}
