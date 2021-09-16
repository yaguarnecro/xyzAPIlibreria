using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using xyzAPIlibreria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace xyzAPIlibreria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LibroController : Controller
    {
        private readonly IConfiguration _configuration;

        public LibroController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Libro";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpGet("{Id_Libro}")]
        public JsonResult Get(int Id_Libro)
        {
            string query = @"select * from Libro Where Id_Libro = @Id_Libro";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Libro", Id_Libro);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet("{Autor}")]
        public JsonResult Get(string Autor)
        {
            string query = @"SELECT l.Id_Libro, l.Titulo, l.Disponible, l.FechaPublicion, a.Nombres, a.Apellidos, u.Tematica, u.Id_Ubicacion 
            FROM Libro AS l 
            INNER JOIN Autor AS a ON l.Id_Autor = a.Id_Autor 
            INNER JOIN Ubicacion as u ON l.Id_Ubicacion = u.Id_Ubicacion
            WHERE CONTAINS (a.Nombres,"+@Autor+");";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Autor", Autor);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Libro libro)
        {
            string query = @"Insert into Libro (Titulo, Disponible, FechaPublicacion, Id_Ubicacíon, Id_Autor) 
                values (@Titulo, @Disponible, @FechaPublicacion, @Id_Ubicacíon, @Id_Autor);";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    myCommand.Parameters.AddWithValue("@Disponible", libro.Disponible);
                    myCommand.Parameters.AddWithValue("@FechaPublicacion", libro.FechaPublicacion);
                    myCommand.Parameters.AddWithValue("@Id_Ubicacion", libro.Id_Ubicacion);
                    myCommand.Parameters.AddWithValue("@Id_Autor", libro.Id_Autor);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Libro libro)
        {
            string query = @"Update Libro set  
Id_Libro=@Id_Libro, Titulo=@Titulo, Disponible=@Disponible, FechaPublicacion=@FechaPublicacion, Id_Ubicacion=@Id_Ubicacion, Id_Autor=@Id_Autor Where Id_Libro = @Id_Libro;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Libro", libro.Id_Libro);
                    myCommand.Parameters.AddWithValue("@Titulo", libro.Titulo);
                    myCommand.Parameters.AddWithValue("@Disponible", libro.Disponible);
                    myCommand.Parameters.AddWithValue("@FechaPublicacion", libro.FechaPublicacion);
                    myCommand.Parameters.AddWithValue("@Id_Ubicacion", libro.Id_Ubicacion);
                    myCommand.Parameters.AddWithValue("@Id_Autor", libro.Id_Autor);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{Id_Libro}")]
        public JsonResult Delete(int Id_Libro)
        {
            string query = @"Delete * from Libro Where Id_Libro = @Id_Libro;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Libro", Id_Libro);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Deleted Successfully");
        }
    }
}
