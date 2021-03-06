﻿using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            HabilidadeHasDisciplina = new HashSet<HabilidadeHasDisciplina>();
            HabilidadePlanoDeEnsino = new HashSet<HabilidadePlanoDeEnsino>();
        }

        public int IdHabilidade { get; set; }
        public string Descricao { get; set; }

        public ICollection<HabilidadeHasDisciplina> HabilidadeHasDisciplina { get; set; }
        public ICollection<HabilidadePlanoDeEnsino> HabilidadePlanoDeEnsino { get; set; }
    }
}
