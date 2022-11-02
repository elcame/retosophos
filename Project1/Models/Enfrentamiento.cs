using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Enfrentamiento
    {
        public int IdRegistro { get; set; }
        public int IdHero { get; set; }
        public int IdVillain { get; set; }
        public string? Resultado { get; set; }

        public virtual Heroe IdHeroNavigation { get; set; } = null!;
        public virtual Villano IdVillainNavigation { get; set; } = null!;
    }
}
