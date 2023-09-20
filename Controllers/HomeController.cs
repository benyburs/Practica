using System.Diagnostics;
using Prac.Models;
using Microsoft.AspNetCore.Mvc;
using practica.Models;
namespace practica.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.ListaAlumnos = BD.SeleccionarAlumnos();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
        public IActionResult VerDetalleAlumno(int id)
    {
        ViewBag.Alumno= BD.AlumnoElegido(id);
        return View();
    }

      public IActionResult CrearAlumno()
        {
            return View();
        }
       public IActionResult GuardarAlumno(Alumnos alumn)
        {
            if (string.IsNullOrEmpty(alumn.nombre))
            {
                ViewBag.Error = "Se deben completar todos los campos";
                return RedirectToAction("CrearAlumno");
            }
            else
            {
                BD.InsertAlumno(alumn);
                return RedirectToAction("index");
            }
}
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    
}
