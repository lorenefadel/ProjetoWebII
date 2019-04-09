using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Curso
    {
        public Curso()
        {
            DisciplinaHasCurso = new HashSet<DisciplinaHasCurso>();
        }

        public int IdCurso { get; set; }
        public string Descricao { get; set; }
        public int CoordenadorIdCoordenador { get; set; }

        public Coordenador CoordenadorIdCoordenadorNavigation { get; set; }
        public ICollection<DisciplinaHasCurso> DisciplinaHasCurso { get; set; }
    }
}
