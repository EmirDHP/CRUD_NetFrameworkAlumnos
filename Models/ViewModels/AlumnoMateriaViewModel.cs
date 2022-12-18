using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Escuelita.Models.ViewModels
{
    public class AlumnoMateriaViewModel
    {
        [Display(Name="Alumnos")]
        public int id_NombreAlumno { get; set; }
        [Display(Name = "Materia")]
        public int id_NombreMateria { get; set; }
        public IEnumerable<SelectListItem> ListaAlumnos { get; set; }
        public IEnumerable<ListaAlumnoMateriaViewModel> ListaMaterias { get; set; }
    }
}