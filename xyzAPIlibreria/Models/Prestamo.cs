using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xyzAPIlibreria.Models
{
    public class Prestamo
    {
        public int Id_Prestamo { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Libro { get; set; }
        public int Usuario { get; set; }
    }
}
