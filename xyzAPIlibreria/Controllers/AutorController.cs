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
{   [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class AutorController : Controller
    {
        private readonly IConfiguration _configuration;

        public AutorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Autor";

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
        [HttpGet("{Id_Autor}")]
        public JsonResult Get(int Id_Autor)
        {
            string query = @"select * from Autor Where Id_Autor = @Id_Autor";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Autor", Id_Autor);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpGet]
        [Route("Nombres")]
        public JsonResult Get(string Nombres)
        {
            string query = @"SELECT l.Id_Libro, l.Titulo, l.Disponible, l.FechaPublicion, a.Nombres, a.Apellidos, u.Tematica, u.Id_Ubicacion 
            FROM Libro AS l 
            INNER JOIN Autor AS a ON l.Id_Autor = a.Id_Autor 
            INNER JOIN Ubicacion as u ON l.Id_Ubicacion = u.Id_Ubicacion
            WHERE CONTAINS (a.Nombres," + @Nombres + ");";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Nombres", Nombres);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Autor autor)
        {
            string query = @"Insert into Autor (Nombres, Apellidos, FechaNacimiento) 
                values (@Nombres, @Apellidos, @FechaNacimiento);";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Nombres", autor.Nombres);
                    myCommand.Parameters.AddWithValue("@Apellidos", autor.Apellidos);
                    myCommand.Parameters.AddWithValue("@FechaNacimiento", autor.FechaNacimiento);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Autor autor)
        {
            string query = @"Update Autor set  Nombres = @Nombres, Apellidos= @Apellidos, FechaNacimiento =  @FechaNacimiento Where Id_Autor = @Id_Autor;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Autor", autor.Id_Autor);
                    myCommand.Parameters.AddWithValue("@Nombres", autor.Nombres);
                    myCommand.Parameters.AddWithValue("@Apellidos", autor.Apellidos);
                    myCommand.Parameters.AddWithValue("@FechaNacimiento", autor.FechaNacimiento);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{Id_Autor}")]
        public JsonResult Delete(int Id_Autor)
        {
            string query = @"Delete * from Autor Where Id_Autor = @Id_Autor;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Autor", Id_Autor);

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
