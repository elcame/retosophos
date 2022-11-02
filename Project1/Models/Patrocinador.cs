using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Patrocinador
    {
        public Patrocinador()
        {
            Patrocinas = new HashSet<Patrocina>();
        }

        public int IdPatrocinador { get; set; }
        public string? OrigenDinero { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Patrocina> Patrocinas { get; set; }
    }
}
