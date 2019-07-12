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
        public ActionResult InsertarExpediente(string Accion)
        {
            ViewBag.Accion = Accion;
            Expediente exp = new Expediente();
            ViewBag.Juzgados = BD.TraerJuzgados();
            ViewBag.TiposExpedientes = BD.TraerTipoDeExpedientes();
            return View(exp);
        }
        public ActionResult FormExpediente(string Accion, int IdEx, int IdJuz)
        {
            Expediente UnExpediente = BD.TraerExpediente(IdEx);
            ViewBag.Juzgados = BD.TraerJuzgados();
            ViewBag.TiposExpedientes = BD.TraerTipoDeExpedientes();
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
                return View("EdicionExpediente", UnExpediente);
            }
            if (Accion == "Eliminar")
            {
                BD.Eliminar(IdEx);
                ViewBag.Expedientes = BD.TraerExpedientes();
                return View("ABMExpedientes");
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
                if (Accion == "Obtener")
                {
                    BD.ModificarExpediente(ex);
                    ViewBag.Expedientes = BD.TraerExpedientes();
                    return View("ABMExpedientes");

                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        BD.InsertarExpediente(ex);
                        ViewBag.Expedientes = BD.TraerExpedientes();
                        return View("ABMExpedientes");
                    }
                }
                //}
                ViewBag.Expedientes = BD.TraerExpedientes();
                return View("ABMExpedientes");
            }
        }
  public ActionResult FormContacto(string Accion, int IdCont)
        {
            Contactos UnContacto = BD.TraerContacto(IdCont);
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
                return View("EdicionContacto", UnContacto);
            }
            if (Accion == "Eliminar")
            {
                BD.EliminarContactos(UnContacto);
                ViewBag.Contactos = BD.TraerContactos();
                return View("ABMContactos");
            }
            return View("SinAccion");
        }
  [HttpPost]
        public ActionResult EdicionContacto(Contactos cont, string Accion)
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
                        BD.InsertarContactos(cont);
                        ViewBag.Contactos = BD.TraerContactos();
                        return View("ABMContactos");
                    }
                }
            }
            else
            {
                return View("InsertarContactos");
            }
            return View("Error");
        }
        public ActionResult InsertarContacto(string Accion)
        {
            ViewBag.Accion = Accion;
            Contactos con = new Contactos();
            return View(con);
        }
        public ActionResult ABMContactos(Contactos contacto)
        {
            ViewBag.Contactos = BD.TraerContactos();
            return View();
        }
        public ActionResult InsertarContactos(string Accion)
        {
            ViewBag.Accion = Accion;
            Contactos con = new Contactos();
            return View(con);
        }
       public ActionResult FormExpedienteContacto(string Accion, int IdContEx)
        {
            ExpedienteContacto UnExpedienteContacto = BD.TraerExpedienteContacto(IdContEx);
            ViewBag.Accion = Accion;
            if (Accion=="VerContactos")
            {
                return View("ContactosExpediente", UnExpedienteContacto);
            }
            return View("SinAccion");
        }
        public ActionResult ContactosExpediente(Expediente ex)
        {
            ViewBag.ExpedienteContacto = BD.TraerExpedientePorContacto();
            ViewBag.ExpedienteContacto = BD.TraerExpedientePorContacto();
            return View();
        }
    }
    }

