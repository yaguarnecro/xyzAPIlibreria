using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace xyzAPIlibreria.Models
{
    
    public class Ubicacion
    {
        [Key]
        public int Id_Ubicacion { get; set; }

        public string Tematica { get; set; }
    }
}
