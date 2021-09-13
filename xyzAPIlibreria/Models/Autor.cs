using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xyzAPIlibreria.Models
{
    public class Autor
    {
        public int Id_Autor { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
