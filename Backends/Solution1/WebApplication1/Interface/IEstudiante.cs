using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface IEstudiante
    {
        List<Estudiante> GetEstudiantes();
        List<Estudiante> PostEstudiante(Estudiante estu);
       
    }
}
