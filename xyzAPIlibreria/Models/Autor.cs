using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace xyzAPIlibreria.Models
{
    public class Autor
    {
        [Key]
        public int Id_Autor { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]$",
         ErrorMessage = "Characters are not allowed.")]
        public string Nombres { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]$",
         ErrorMessage = "Characters are not allowed.")]
        public string Apellidos { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
    }
}
