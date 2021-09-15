using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyzAPIlibreria.Models
{
    public class Libro
    {
        [Key]
        public int Id_Libro { get; set; }

        public string Titulo { get; set; }
        public int Disponible { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaPublicacion { get; set; }
        [ForeignKey("Id_Ubicacion")]
        public int Id_Ubicacion { get; set; }
        [ForeignKey("Id_Autor")]
        public int Id_Autor { get; set; }

    }
}
