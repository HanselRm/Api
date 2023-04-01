using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class EstudianteService : IEstudiante
    {
        
        public List<Estudiante> GetEstudiantes()
        {
            List<Estudiante> list = new List<Estudiante>();
            try
            {
                StreamReader file2 = new StreamReader(@"C:\Users\hanse\Escritorio\Carpetas\Itla\Programacion\Asignacion 4\json.json");
                string json = file2.ReadToEnd();
                file2.Close();

                list = JsonConvert.DeserializeObject<List<Estudiante>>(json);
            }
            catch(Exception ex)
            {

            }
            
            
            return list;
        }

        public List<Estudiante> PostEstudiante(Estudiante estu)
        {
            List<Estudiante> list = new List<Estudiante>();
            try
            {
                string archivo = File.ReadAllText(@"C:\Users\hanse\Escritorio\Carpetas\Itla\Programacion\Asignacion 4\json.json");
                list = JsonConvert.DeserializeObject<List<Estudiante>>(archivo);
            }
            catch(System.IO.FileNotFoundException e) 
            {
                e.GetBaseException();
            }
           

            
            try
            {
                list.Add(estu);
            }
            catch(Exception ex)
            {
                list = new List<Estudiante>();
                list.Add(estu);
            }
    
            string json = JsonConvert.SerializeObject(list);

         

            File.WriteAllText(@"C:\Users\hanse\Escritorio\Carpetas\Itla\Programacion\Asignacion 4\json.json", json);
           
            return list;
        }
    }
}
