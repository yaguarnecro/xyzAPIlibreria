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
    public class UbicacionController : Controller
    {
        private readonly IConfiguration _configuration;

        public UbicacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Ubicacion";

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
        [HttpGet("{Id_Ubicacion}")]
        public JsonResult Get(int Id_Ubicacion)
        {
            string query = @"select * from Ubicacion Where Id_Ubicacion = @Id_Ubicacion";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Ubicacion", Id_Ubicacion);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        //[HttpGet("{Tema")]
        //public JsonResult Get(string Tema)
        //{
        //    string query = @"SELECT l.Id_Libro, l.Titulo, l.Disponible, l.FechaPublicion, a.Nombres, a.Apellidos, u.Tematica, u.Id_Ubicacion 
        //    FROM Libro AS l 
        //    INNER JOIN Autor AS a ON l.Id_Autor = a.Id_Autor 
        //    INNER JOIN Ubicacion as u ON l.Id_Ubicacion = u.Id_Ubicacion
        //    WHERE CONTAINS (u.Tematica," + @Tema + ");";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("sql10436778");
        //    MySqlDataReader myReader;
        //    using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
        //    {
        //        mycon.Open();
        //        using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
        //        {
        //            myCommand.Parameters.AddWithValue("@Tema", Tema);

        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            mycon.Close();
        //        }
        //    }
        //    return new JsonResult(table);
        //}
        [HttpPost]
        public JsonResult Post(Ubicacion ubicacion)
        {
            string query = @"Insert into Ubicación (Tematica) values (@Tematica);";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Tematica", ubicacion.Tematica);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Ubicacion ubicacion)
        {
            string query = @"Update Ubicacion set  Tematica = @Tematica Where Id_Ubicacion = @Id_Ubicacion;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Ubicacion", ubicacion.Id_Ubicacion);
                   
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{Id_Ubicacion}")]
        public JsonResult Delete(int Id_Ubicacion)
        {
            string query = @"Delete from Ubicacion Where Id_Ubicacion = @Id_Ubicacion;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Ubicacion", Id_Ubicacion);

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