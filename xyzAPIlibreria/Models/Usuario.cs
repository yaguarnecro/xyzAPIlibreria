using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xyzAPIlibreria.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Rol { get; set; }
    }
}
