using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Objetivo
    {
        public Objetivo()
        {
            ObjetivoHasDisciplina = new HashSet<ObjetivoHasDisciplina>();
            ObjetivoPlanoDeEnsino = new HashSet<ObjetivoPlanoDeEnsino>();
        }

        public int IdObjetivo { get; set; }
        public string Descricao { get; set; }

        public ICollection<ObjetivoHasDisciplina> ObjetivoHasDisciplina { get; set; }
        public ICollection<ObjetivoPlanoDeEnsino> ObjetivoPlanoDeEnsino { get; set; }
    }
}
