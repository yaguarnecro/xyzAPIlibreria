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
    public class UsuarioController : Controller
    {
        private readonly IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from Usuario";

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
        [HttpGet("{Id_Usuario}")]
        public JsonResult Get(int Id_Usuario)
        {
            string query = @"select * from Usuario Where Id_Usuario = @Id_Usuario";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult Post(Usuario usuario)
        {
            string query = @"Insert into Usuario (Nombres, Apellidos, Email, Password, Id_Rol) 
                values (@Nombres, @Apellidos, @Email, @Password, @Id_Rol);";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                    myCommand.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                    myCommand.Parameters.AddWithValue("@Email", usuario.Email);
                    myCommand.Parameters.AddWithValue("@Password", usuario.Password);
                    myCommand.Parameters.AddWithValue("@Id_Rol", usuario.Id_Rol);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(Usuario usuario)
        {
            string query = @"Update Usuario set Id_Usuario = @Id_Usuario, Nombres = @Nombres, Apellidos= @Apellidos, Email= @Email, Password=@Password, Id_Rol= @Id_Rol Where Id_Autor = @Id_Autor;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Usuario", usuario.Id_Usuario);
                    myCommand.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                    myCommand.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                    myCommand.Parameters.AddWithValue("@Email", usuario.Email);
                    myCommand.Parameters.AddWithValue("@Password", usuario.Password);
                    myCommand.Parameters.AddWithValue("@Id_Rol", usuario.Id_Rol);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }
        [HttpDelete("{Id_Usuario}")]
        public JsonResult Delete(int Id_Usuario)
        {
            string query = @"Delete from Usuario Where Id_Usuario = @Id_Usuario;";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("sql10436778");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);

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
