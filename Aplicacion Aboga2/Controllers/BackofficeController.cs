using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Aboga2.Models;
namespace Aplicacion_Aboga2.Controllers
{
    public class BackofficeController : Controller
    {
        // GET: Backoffice
        public ActionResult Menu()
        {
            return View();
        }
        /*public ActionResult ABMContactos(Contactos cts)
        {
            ViewBag.Contactos = BD.TraerContactos();
            return View();
        }
        public ActionResult InsertarContactos(string Accion)
        {
            ViewBag.Accion = Accion;
            return View();
        }
        public ActionResult FormContactos(string Accion, int IdCts)
        {
            ViewBag.Contactos = BD.TraerContactos();
            return View();
        }*/

        public ActionResult ABMExpedientes(Expediente ex)
        {
            ViewBag.Expedientes = BD.TraerExpedientes();
            return View();
        }
        public ActionResult ABMContactos(Contacto contacto)
        {
            ViewBag.Contactos = BD.TraerContactos();
            return View();
        }

        public ActionResult ABMExpedienteFojas(ExpedienteFojas Expf, int IdEx)
        {
            ViewBag.ExpedienteFojas = BD.TraerLasExpFojas(IdEx);
            return View();
        }

        public ActionResult InsertarExpediente(string Accion)
        {
            ViewBag.Accion = Accion;
            return View();
        }
        public ActionResult InsertarContacto(string Accion)
        {
            ViewBag.Accion = Accion;
            Contacto con = new Contacto();
            return View(con);
        }

        public ActionResult InsertarExpedienteFojas(string Accion)
        {
            ViewBag.Accion = Accion;
            ExpedienteFojas Expf = new ExpedienteFojas();
            return View(Expf);
        }

        public ActionResult FormExpediente(string Accion, int IdEx)
        {
            Expediente UnExpediente = BD.TraerExpediente(IdEx);
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
               return View("EdicionExpediente", UnExpediente);
            }
            if (Accion=="Eliminar")
            {
                BD.Eliminar(IdEx);
                ViewBag.Expedientes = BD.TraerExpedientes();
                return View("ABMExpedientes");
            }
            return View("SinAccion");
        }
        public ActionResult FormContacto(string Accion, int IdCont)
        {
            Contacto UnContacto = BD.TraerContacto(IdCont);
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
                return View("EdicionContacto", UnContacto);
            }
            if (Accion == "Eliminar")
            {
                BD.EliminarContactos(IdCont);
                ViewBag.Contactos = BD.TraerContactos();
                return View("ABMContactos");
            }
            return View("SinAccion");
        }

        public ActionResult FormExpedienteFojas(string Accion, int IdExpf,int IdEx)
        {
            ExpedienteFojas UnexpedienteFojas= BD.TraerExpediente_fojas(IdExpf);
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
                return View("EdicionExpedienteFojas", UnexpedienteFojas);
            }
            if (Accion == "Eliminar")
            {
                BD.EliminarContactos(IdExpf);
                ViewBag.ExpedienteFojas = BD.TraerLasExpFojas(IdEx);
                return View("ABMExpedientesFojas");
            }
            return View("SinAccion");
        }




        [HttpPost]
        public ActionResult EdicionExpediente(Expediente ex, string Accion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Expedientes = BD.TraerExpedientes();
                return View("ABMExpedientes");
            }
            else
            {
                if(Accion == "Obtener")
                {
                    BD.ModificarExpediente(ex);
                    ViewBag.Expedientes = BD.TraerExpedientes();
                    return View("ABMExpedientes");
                    
                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        if (!ModelState.IsValid)
                        {
                            ViewBag.Expedientes = BD.InsertarExpediente(ex);
                            return View("InsertarExpediente");
                        }
                        else
                        {
                            BD.InsertarExpediente(ex);
                            ViewBag.Expedientes = BD.InsertarExpediente(ex);
                            return View("ABMExpedientes");
                        }
                    }
                }
            }
            ViewBag.Expedientes = BD.TraerExpedientes();
            return View("ABMExpedientes");
        }
        [HttpPost]
        public ActionResult EdicionContacto(Contacto cont, string Accion)
        {
            if (ModelState.IsValid)
            {
                if (Accion == "Obtener")
                {
                    BD.ModificarContacto(cont);
                    ViewBag.Contactos = BD.TraerContactos();
                    return View("ABMContactos");

                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        BD.InsertarContacto(cont);
                        ViewBag.Contactos = BD.TraerContactos();
                        return View("ABMContactos");
                    }
                }
            }
            else
            {
                return View("InsertarContacto");
            }
            return View("Error");
        }


        [HttpPost]
        public ActionResult EdicionExpedienteFojas(ExpedienteFojas Expf, string Accion, int IdEx)
        {
            if (ModelState.IsValid)
            {
                if (Accion == "Obtener")
                {
                    BD.ModificarExpFojas(Expf);
                    ViewBag.ExpedienteFojas = BD.TraerLasExpFojas(IdEx);
                    return View("ABMExpedientesFojas");

                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        BD.InsertarFojas(Expf);
                        ViewBag.ExpedienteFojas = BD.TraerLasExpFojas(IdEx);
                        return View("ABMExpedientesFojas");
                    }
                }
            }
            else
            {
                return View("InsertarFojas");
            }
            return View("Error");
        }

    }
}

  