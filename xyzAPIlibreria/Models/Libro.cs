using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xyzAPIlibreria.Models
{
    public class Libro
    {
        public int Id_Libro { get; set; }

        public string Titulo { get; set; }
        public int Disponible { get; set; }

        public DateTime FechaPublicacion { get; set; }
        public int Id_Ubicacion { get; set; }
        public int Id_Autor { get; set; }

    }
}
