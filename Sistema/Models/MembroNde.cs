using System;
using System.Collections.Generic;

namespace Sistema.Models
{
    public partial class MembroNde
    {
        public int IdMembroNde { get; set; }
        public int? IdPlanoDeEnsino { get; set; }
        public string Nome { get; set; }

        public PlanoDeEnsino IdPlanoDeEnsinoNavigation { get; set; }
    }
}
