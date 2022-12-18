using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Escuelita.Models.ViewModels
{
    public class AlumnoViewModel
    {
        public int Id_Alumno { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        public string Nombre_Alumno { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido_Alumno { get; set; }
        [Required]
        [Display(Name = "Matricula")]
        public string Matricula { get; set; }
        [Display(Name = "Ingles")]
        public bool Ingles { get; set; }

        [Display(Name = "Español")]
        public bool Espanol { get; set; }

        [Display(Name = "Matematicas")]
        public bool Matematicas { get; set; }

        [Display(Name = "Ciencias")]
        public bool Ciencias { get; set; }




        //[Display(Name = "Nombre Materia")]
        //public string Materia_Nombre { get; set; }
    }
}