using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Patrocina
    {
        public int IdPatrocinio { get; set; }
        public int? IdPatrocinador { get; set; }
        public int? IdHero { get; set; }
        public int? Monto { get; set; }

        public virtual Heroe? IdHeroNavigation { get; set; }
        public virtual Patrocinador? IdPatrocinadorNavigation { get; set; }
    }
}
