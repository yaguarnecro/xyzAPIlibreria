using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace xyzAPIlibreria.Models
{
    public class ROL
    {
        [Key]
        public int Id_Rol { get; set; }

        public string Nombre { get; set; }
    }
}
