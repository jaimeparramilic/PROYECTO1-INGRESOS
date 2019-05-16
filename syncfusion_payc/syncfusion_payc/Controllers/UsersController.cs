using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using syncfusion_payc.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace syncfusion_payc.Controllers
{
	[Authorize]
	public class UsersController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();
        // GET: Users
        public Boolean isAdminUser()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				ApplicationDbContext context = new ApplicationDbContext();
				var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
				var s = UserManager.GetRoles(user.GetUserId());
				if (s[0].ToString() == "Admin")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
		public ActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				ViewBag.Name = user.Name;
				ApplicationDbContext context = new ApplicationDbContext();
				var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                //Cargue de atributos usuario
                var s =	UserManager.GetRoles(user.GetUserId());
                ViewBag.Rol = s[0].ToString();
                if (s[0].ToString() == "temporal")
                {
                    string cod_compromiso_string = user.Name.ToString().Replace("TEMPORAL_", "");
                    int i = 0;
                    if (!Int32.TryParse(cod_compromiso_string, out i))
                    {
                        i = -1;
                    }

                    long ii = (long)i;

                    //Cargue de atributos necesarios para la vista
                    ACUERDOS_PAGO_ENTREGAB acu = db.ACUERDOS_PAGO_ENTREGAB.Single(o => o.COD_ACUERDO_PAGO == ii);
                    VISTA_GESTION_CARTERA cart = db.VISTA_GESTION_CARTERA.Single(o => o.COD_CARTERA == acu.COD_CARTERA);
                    CONTRATO_PROYECTO cont_pro = db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == cart.COD_CONTRATO_PROYECTO);
                    CONTRATOS cont = db.CONTRATOS.Single(o => o.COD_CONTRATO == cont_pro.COD_CONTRATO);
                    CLIENTES cli = db.CLIENTES.Single(o => o.COD_CLIENTE == cont.COD_CLIENTE);
                    PROYECTOS pro = db.PROYECTOS.Single(o => o.COD_PROYECTO == cont_pro.COD_PROYECTO);

                    try
                    {
                        GESTION_ENTREGABLES gesten = db.GESTION_ENTREGABLES.Single(o => o.COD_ACUERDO_PAGO == acu.COD_ACUERDO_PAGO);
                        ViewBag.RUTA = "ACUERDOS_PAGO_ENTREGAB/entregables/" + gesten.URL_ARCHIVO;
                        ViewBag.NOMBRE_ARCHIVO = gesten.URL_ARCHIVO.ToString().Replace("%20", " ");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.RUTA = "";
                        ViewBag.NOMBRE_ARCHIVO = "";
                    }

                    ViewBag.cont_pro = cont_pro;
                    ViewBag.cont = cont;
                    ViewBag.cli = cli;
                    ViewBag.pro = pro;
                    ViewBag.cart = cart;
                    ViewBag.acu = acu;
                }
                ViewBag.displayMenu = "No";
				if (isAdminUser())
				{
					ViewBag.displayMenu = "Yes";
				}
				return View();
			}
			else
			{
				ViewBag.Name = "Not Logged IN";
			}


			return View();


		}
	}
}