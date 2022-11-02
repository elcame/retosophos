using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Relacione
    {
        public int IdRelacion { get; set; }
        public int? IdHero { get; set; }
        public string? Tipo { get; set; }
        public string? Contacto { get; set; }

        public virtual Heroe? IdHeroNavigation { get; set; }
    }
}
