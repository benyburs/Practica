using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
namespace Prac.Models
{
    public static class BD
    {
        private static string _connectionString = @"Server=localhost;DataBase=GestionAlumnos;Trusted_Connection=True;";

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
            string SQL = "SELECT * FROM Alumnos WHERE id= @pid";
            Elegido = db.QueryFirstOrDefault<Alumnos>(SQL, new { pid= id });
        }
        return Elegido;
    }
public static void InsertAlumno(Alumnos alumno)
{
    string SQL = "INSERT INTO Alumnos(nombre, apellido, curso, edad)";
    SQL += " VALUES (@pNombre, @pApellido, @pCurso, @pEdad)";

    using (SqlConnection db = new SqlConnection(_connectionString))
    {
        db.Execute(SQL, new
        {
            pNombre = alumno.nombre,
            pApellido = alumno.apellido,
            pCurso = alumno.curso,
            pEdad = alumno.edad
        });
    }
}


    
    }
}