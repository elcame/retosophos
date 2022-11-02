using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Heroe
    {
        public Heroe()
        {
            Enfrentamientos = new HashSet<Enfrentamiento>();
            Patrocinas = new HashSet<Patrocina>();
            Relaciones = new HashSet<Relacione>();
        }

        public int IdHero { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public int? Edad { get; set; }
        public string HabilidadesPoderes { get; set; } = null!;
        public string? Debilidades { get; set; }
        public DateTime? Disponibilidad { get; set; }

        public virtual ICollection<Enfrentamiento> Enfrentamientos { get; set; }
        public virtual ICollection<Patrocina> Patrocinas { get; set; }
        public virtual ICollection<Relacione> Relaciones { get; set; }
    }
}
