using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using xyzAPIlibreria.Models;

namespace xyzAPIlibreria.Data
{
    public class ApiDbContext:IdentityDbContext
    {
        

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Libro> Libros{ get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<ROL> ROLs { get; set; }
        public virtual DbSet<Ubicacion> Ubicaciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
