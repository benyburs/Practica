using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace Prac.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=localhost\SQLEXPRESS;Database=GestionAlumnos;Integrated Security=True;";
        
        public static List<Alumnos> SeleccionarAlumnos()
        {
            List<Alumnos> ListaAlumnos;
            using(SqlConnection db = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Alumnos";
                ListaAlumnos = db.Query<Alumnos>(sql).ToList();
            }
            return ListaAlumnos;
        }
    
       public static Alumnos AlumnoElegido(int id)
    {
        Alumnos Elegido = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string SQL = "SELECT * FROM Alumnos WHERE id= id";
            Elegido = db.QueryFirstOrDefault<Alumnos>(SQL, new { Alumnos= id });
        }
        return Elegido;
    }
    }
}