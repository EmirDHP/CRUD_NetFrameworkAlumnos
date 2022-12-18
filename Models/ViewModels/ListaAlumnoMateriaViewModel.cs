using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Escuelita.Models.ViewModels
{
    public class ListaAlumnoMateriaViewModel
    {
        public int id_materia { get; set; }
        public string materia { get; set; }
        public bool IsSelected { get; set; }
    }
}