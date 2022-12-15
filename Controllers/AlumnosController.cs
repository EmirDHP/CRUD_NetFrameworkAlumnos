using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escuelita.Models;
using Escuelita.Models.ViewModels;

namespace Escuelita.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            List<ListaAlumnoViewModel> lst;
            using (SchoolEntities db = new SchoolEntities())
            {
                lst = (from d in db.Alumnos
                           select new ListaAlumnoViewModel
                           {
                               Id_Alumno = d.id_alumno,
                               Nombre_Alumno = d.nombre_alumno,
                               Apellido_Alumno = d.apellido_alumno,
                               Matricula = d.matricula_alumno
                           }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            //SchoolEntities db = new SchoolEntities();

            //lista_materias lstMaterias = new lista_materias();
            //lstMaterias.listaMaterias = db.Materias.ToList<Materia>();
            //ViewBag.message = Convert.ToString(TempData["message"]);

            //return View(lstMaterias);
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(AlumnosViewModel model, string InglesM, string EspanolM, string MatematicasM, string CienciasM)
        {
            try
            {



                if (ModelState.IsValid)
                {

                    using(SchoolEntities db = new SchoolEntities())
                    {


                        var oAlumnos = new Alumno();
                        oAlumnos.nombre_alumno = model.Nombre_Alumno;
                        oAlumnos.apellido_alumno = model.Apellido_Alumno;
                        oAlumnos.matricula_alumno = model.Matricula;


                        if (InglesM == "true")
                        {
                            oAlumnos.ingles_materia = model.Ingles == false;
                        }
                        else
                        {                            
                            oAlumnos.ingles_materia = model.Ingles == true;
                        }

                        if (EspanolM == "true")
                        {
                            oAlumnos.espanol_materia = model.Espanol == false;
                        }
                        else
                        {
                            oAlumnos.espanol_materia = model.Espanol == true;                           
                        }
                        if (MatematicasM == "true")
                        {
                            oAlumnos.matematicas_materia = model.Matematicas == false;
                        }
                        else
                        {                            
                            oAlumnos.matematicas_materia = model.Matematicas == true;
                        }
                        if (CienciasM == "true")
                        {
                            oAlumnos.ciencias_materia = model.Ciencias == false;
                        }
                        else
                        {                            
                            oAlumnos.ciencias_materia = model.Ciencias == true;
                        }


                        db.Alumnos.Add(oAlumnos);
                        db.SaveChanges();
                    }                  

                    TempData["success"] = "¡El alumno se ha creado con éxito!.";
                    return Redirect("~/Alumnos");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ActionResult Editar(int id)
        {
            AlumnosViewModel model = new AlumnosViewModel();
            using (SchoolEntities db = new SchoolEntities())
            {
                var oAlumno = db.Alumnos.Find(id);
                model.Nombre_Alumno = oAlumno.nombre_alumno;
                model.Apellido_Alumno = oAlumno.apellido_alumno;
                model.Matricula = oAlumno.matricula_alumno;
                model.Id_Alumno = oAlumno.id_alumno;
                model.Ingles = oAlumno.ingles_materia ?? false;
                model.Matematicas = oAlumno.matematicas_materia ?? false;
                model.Espanol = oAlumno.espanol_materia ?? false;
                model.Ciencias = oAlumno.ciencias_materia ?? false;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(AlumnosViewModel model, string InglesM, string EspanolM, string MatematicasM, string CienciasM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolEntities db = new SchoolEntities())
                    {
                        var oAlumno = db.Alumnos.Find(model.Id_Alumno);
                        oAlumno.nombre_alumno = model.Nombre_Alumno;
                        oAlumno.apellido_alumno = model.Apellido_Alumno;
                        oAlumno.matricula_alumno = model.Matricula;


                        if (InglesM == "true")
                        {
                            oAlumno.ingles_materia = model.Ingles == false;
                        }
                        else
                        {
                            oAlumno.ingles_materia = model.Ingles == true;
                        }

                        if (EspanolM == "true")
                        {
                            oAlumno.espanol_materia = model.Espanol == false;
                        }
                        else
                        {
                            oAlumno.espanol_materia = model.Espanol == true;
                        }
                        if (MatematicasM == "true")
                        {
                            oAlumno.matematicas_materia = model.Matematicas == false;
                        }
                        else
                        {
                            oAlumno.matematicas_materia = model.Matematicas == true;
                        }
                        if (CienciasM == "true")
                        {
                            oAlumno.ciencias_materia = model.Ciencias == false;
                        }
                        else
                        {
                            oAlumno.ciencias_materia = model.Ciencias == true;
                        }


                        db.Entry(oAlumno).State = System.Data.Entity.EntityState.Modified; 
                        db.SaveChanges();
                    }
                    TempData["EditSuccess"] = "¡El alumno ha sido editado!.";
                    return Redirect("~/Alumnos");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            AlumnosViewModel model = new AlumnosViewModel();
            using (SchoolEntities db = new SchoolEntities())
            {                
                var oAlumno = db.Alumnos.Find(id);
                db.Alumnos.Remove(oAlumno);
                db.SaveChanges();
            }
            TempData["DeleteSuccess"] = "¡El alumno ha sido con éxito!.";
            return Redirect("~/Alumnos");
        }
    }
}