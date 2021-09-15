using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyzAPIlibreria.Models
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]$",
 ErrorMessage = "Characters are not allowed.")]
        public string Nombres { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]$",
 ErrorMessage = "Characters are not allowed.")]
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("Id_Rol")]
        public int Id_Rol { get; set; }
    }
}
