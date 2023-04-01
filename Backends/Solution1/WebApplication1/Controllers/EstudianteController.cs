using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase
    {
        IEstudiante service;

        public EstudianteController(IEstudiante service)
        {
            this.service = service;
        }

        [HttpGet("obtener")]
        public dynamic GetEstudiante()
        {
            return service.GetEstudiantes();
        }

        [HttpPost("agregar")]
        public dynamic PostEstudiante(Estudiante estu)
        {
            return service.PostEstudiante(estu);
        }
    }
}
