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
        public bool Disponible { get; set; }

        public DateTime FechaPublicación { get; set; }
        public int Ubicacion { get; set; }
        public int Autor { get; set; }

    }
}
