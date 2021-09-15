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

namespace xyzAPIlibreria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : Controller
    {
        private readonly IConfiguration _configuration;

        public PrestamoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Prestamo";

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
        [HttpGet("{Id_Prestamo}")]
        public JsonResult Get(int Id_Prestamo)
        {
            string query = @"select * from Prestamo Where Id_Prestamo = @Id_Prestamo";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Prestamo", Id_Prestamo);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Prestamo prestamo)
        {
            string query = @"Insert into Prestamo (FechaFin, FechaInicio, Id_Usuario, Id_Libro) 
                values (@FechaFin, @FechaInicio, @Id_Usuario, @Id_Libro);";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@FechaFin", prestamo.FechaFin);
                    myCommand.Parameters.AddWithValue("@FechaInicio", prestamo.FechaInicio);
                    myCommand.Parameters.AddWithValue("@Id_Usuario", prestamo.Id_Usuario);
                    myCommand.Parameters.AddWithValue("@Id_Libro", prestamo.Id_Libro);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Prestamo prestamo)
        {
            string query = @"Update Prestamo set  Id_Autor = @Id_Autor, FechaInicio= @FechaInicio, FechaFin = @FechaFin, Id_Usuario=@Id_Usuario, Id_Libro=@Id_Libro  Where Id_Libro = @Id_Libro;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Prestamo", prestamo.Id_Prestamo);
                    myCommand.Parameters.AddWithValue("@FechaFin", prestamo.FechaFin);
                    myCommand.Parameters.AddWithValue("@FechaInicio", prestamo.FechaInicio);
                    myCommand.Parameters.AddWithValue("@Id_Usuario", prestamo.Id_Usuario);
                    myCommand.Parameters.AddWithValue("@Id_Libro", prestamo.Id_Libro);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{Id_Prestamo}")]
        public JsonResult Delete(int Id_Prestamo)
        {
            string query = @"Delete * from Prestamo Where Id_Prestamo = @Id_Prestamo;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Prestamo", Id_Prestamo);

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
