using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Villano
    {
        public Villano()
        {
            Enfrentamientos = new HashSet<Enfrentamiento>();
        }

        public int IdVillain { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public int? Edad { get; set; }
        public string HabilidadesPoderes { get; set; } = null!;
        public string? Debilidades { get; set; }
        public string? Origen { get; set; }

        public virtual ICollection<Enfrentamiento> Enfrentamientos { get; set; }
    }
}
