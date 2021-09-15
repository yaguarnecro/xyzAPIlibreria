using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyzAPIlibreria.Models
{
    public class Prestamo
    {
        [Key]
        public int Id_Prestamo { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }
        [ForeignKey("Id_Libro")]
        public int Id_Libro { get; set; }
        [ForeignKey("Id_Usuario")]
        public int Id_Usuario { get; set; }
    }
}
