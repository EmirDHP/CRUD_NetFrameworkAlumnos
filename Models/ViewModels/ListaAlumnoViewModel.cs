using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escuelita.Models.ViewModels
{
    public class ListaAlumnoViewModel
    {
        public int Id_Alumno { get; set; }
        public string Nombre_Alumno { get; set; }
        public string Apellido_Alumno { get; set; }
        public string Matricula { get; set; }
        public bool Ingles { get; set; }
        public bool Espanol { get; set; }
        public bool Matematicas { get; set; }
        public bool Ciencias { get; set; }
    }
}