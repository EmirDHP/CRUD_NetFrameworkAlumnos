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
        // ++++++++++++ TABLA ALUMNOS ++++++++++++ //
        #region Tabla alumnos
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
        #endregion

        // ++++++++++++ CREAR ALUMNOS ++++++++++++ //
        #region Crear Alumnos
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(AlumnoViewModel model, string InglesM, string EspanolM, string MatematicasM, string CienciasM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SchoolEntities db = new SchoolEntities())
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
        #endregion

        // ++++++++++++ EDITAR ALUMNOS ++++++++++++ //
        #region Editar Alumnos
        public ActionResult Editar(int id)
        {
            AlumnoViewModel model = new AlumnoViewModel();
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
        public ActionResult Editar(AlumnoViewModel model, string InglesM, string EspanolM, string MatematicasM, string CienciasM)
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
        #endregion

        // ++++++++++++ ELIMINAR ALUMNOS ++++++++++++ //
        #region Eliminar Alumnos
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            AlumnoViewModel model = new AlumnoViewModel();
            using (SchoolEntities db = new SchoolEntities())
            {
                var oAlumno = db.Alumnos.Find(id);
                db.Alumnos.Remove(oAlumno);
                db.SaveChanges();
            }
            TempData["DeleteSuccess"] = "¡El alumno ha sido con éxito!.";
            return Redirect("~/Alumnos");
        }
        #endregion

        // ++++++++++++ ASIGNAR MATERAS A ALUMNOS ++++++++++++ //
        #region Asignar Materias Alumnos
        private SchoolEntities objSchoolEntities;
        public AlumnosController()
        {
            objSchoolEntities = new SchoolEntities();
        }

        public ActionResult AsignarMateriasAlumnos()
        {
            AlumnoMateriaViewModel objMateriaViewModel = new AlumnoMateriaViewModel()
            {
                ListaAlumnos = (from objAlumnos in objSchoolEntities.Alumnos
                                select new SelectListItem()
                                {
                                    Text = objAlumnos.nombre_alumno,
                                    Value = objAlumnos.id_alumno.ToString()
                                }).ToList(),
                ListaMaterias = (from objMaterias in objSchoolEntities.Materias
                                 select new ListaAlumnoMateriaViewModel()
                                 {
                                     id_materia = objMaterias.id_materia,
                                     materia = objMaterias.materia_nombre,
                                     IsSelected = false
                                 }).ToList()
            };
            return View(objMateriaViewModel);
        }

        [HttpPost]
        public JsonResult AsignarMateriasAlumnos(int id_alumno, List<int> ListaMateriasId)
        {
            if (objSchoolEntities.AlumnoMaterias.Any(model => model.alumno_id == id_alumno))
            {
                objSchoolEntities.AlumnoMaterias.RemoveRange(
                    objSchoolEntities.AlumnoMaterias.Where(model => model.alumno_id == id_alumno));
                objSchoolEntities.SaveChanges();
            }
            foreach (var item in ListaMateriasId)
            {
                AlumnoMateria objAlumnoMateria = new AlumnoMateria();
                objAlumnoMateria.alumno_id = id_alumno;
                objAlumnoMateria.materia_id = item;
                objSchoolEntities.AlumnoMaterias.Add(objAlumnoMateria);
                objSchoolEntities.SaveChanges();
            }
            return Json(new { success = true, message = "Se asignaron correctamente las mateias!" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Vista parcial para las materias de los alumnos en la vista AsignarMateria
        /// </summary>
        public ActionResult TablaAlumnoMaterias()
        {
            List<ListaAlumnoViewModel> lst;
            using (SchoolEntities db = new SchoolEntities())
            {
                lst = (from a in db.Alumnos
                       join am in db.AlumnoMaterias
                       on a.id_alumno equals am.alumno_id
                       join m in db.Materias
                       on am.materia_id equals m.id_materia
                       select new ListaAlumnoViewModel
                       {
                           Id_Alumno = a.id_alumno,
                           Nombre_Alumno = a.nombre_alumno,
                           Apellido_Alumno = a.apellido_alumno,
                           Matricula = a.matricula_alumno,
                           Materia_Nombre = m.materia_nombre
                       }).ToList();
            }
            return View(lst);
        }
        #endregion
    }
}