using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using clientesApp.Models;
using clientesApp.Models.viewModels;

namespace clientesApp.Controllers
{
    public class clientesController : Controller
    {
        // GET: clientes
        public ActionResult Index(string busqueda = "")
        {
            List<listaClientesViewModel> lista;

            using (clientesDBEntities cnn = new clientesDBEntities())
            {
                lista = (from clie in cnn.clientes
                         select new listaClientesViewModel
                         {
                             codCliente = clie.codCliente,
                             nombreCliente = clie.nombreCliente,
                             telefonoCliente = clie.telefonoCliente,
                             correoCliente = clie.correoCliente,
                             duiCliente = clie.duiCliente,
                         }).ToList();
            }

            return View(lista);
        }

        public ActionResult nuevoCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult nuevoCliente(clientesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (clientesDBEntities cnn = new clientesDBEntities())
                    {
                        var oClientes = new clientes();
                        oClientes.duiCliente = model.duiCliente;
                        oClientes.nombreCliente = model.nombreCliente;
                        oClientes.telefonoCliente = model.telefonoCliente;
                        oClientes.correoCliente = model.correoCliente;

                        cnn.clientes.Add(oClientes);
                        cnn.SaveChanges();
                    }
                    return Redirect("~/clientes/");
                }

                return View(model);
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult editarCliente(int id)
        {
            clientesViewModel clienteTb = new clientesViewModel();

            using (clientesDBEntities cnn = new clientesDBEntities()) {

                var oClientes = cnn.clientes.Find(id);
                clienteTb.nombreCliente = oClientes.nombreCliente;
                clienteTb.duiCliente = oClientes.duiCliente;
                clienteTb.telefonoCliente = oClientes.telefonoCliente;
                clienteTb.correoCliente = oClientes.correoCliente;
                clienteTb.codCliente = oClientes.codCliente;

            }

                return View(clienteTb);
        }

        [HttpPost]
        public ActionResult editarCliente(clientesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (clientesDBEntities cnn = new clientesDBEntities())
                    {
                        var oClientes = cnn.clientes.Find(model.codCliente);
                        oClientes.duiCliente = model.duiCliente;
                        oClientes.nombreCliente = model.nombreCliente;
                        oClientes.telefonoCliente = model.telefonoCliente;
                        oClientes.correoCliente = model.correoCliente;

                        cnn.Entry(oClientes).State = System.Data.Entity.EntityState.Modified;
                        cnn.SaveChanges();
                    }
                    return Redirect("~/clientes/");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace);
            }
        }


        [HttpGet]
        public ActionResult eliminarCliente(int id)
        {
            using (clientesDBEntities cnn = new clientesDBEntities())
            {
                var oClientes = cnn.clientes.Find(id);
                cnn.clientes.Remove(oClientes);
                cnn.SaveChanges();

            }

            return Redirect("~/clientes/");
        }

    }
}