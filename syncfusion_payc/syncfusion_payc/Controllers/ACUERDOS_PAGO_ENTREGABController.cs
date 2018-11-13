using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.JavaScript;
using Syncfusion.JavaScript.DataSources;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using syncfusion_payc.Models;
using syncfusion_payc.Utilidades;
using System.Security.Claims;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace syncfusion_payc.Controllers
{
    public class ACUERDOS_PAGO_ENTREGABController : Controller
    {
        private test_payc_contabilidadEntities db = new test_payc_contabilidadEntities();

        // GET: ACUERDOS_PAGO_ENTREGAB
        public ActionResult Index()
        {
            var aCUERDOS_PAGO_ENTREGAB = db.ACUERDOS_PAGO_ENTREGAB.Include(a => a.CARTERA).Include(a => a.ESTADOS_ACUER_PAG_ENTREG).Include(a => a.TIPOS_ACUERDO);
            return View(aCUERDOS_PAGO_ENTREGAB.ToList());
        }

        // GET: ACUERDOS_PAGO_ENTREGAB/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACUERDOS_PAGO_ENTREGAB aCUERDOS_PAGO_ENTREGAB = db.ACUERDOS_PAGO_ENTREGAB.Find(id);
            if (aCUERDOS_PAGO_ENTREGAB == null)
            {
                return HttpNotFound();
            }
            return View(aCUERDOS_PAGO_ENTREGAB);
        }

        // GET: ACUERDOS_PAGO_ENTREGAB/Create
        public ActionResult Create()
        {
            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "UserName");
            ViewBag.COD_ESTADO_ACUERDO = new SelectList(db.ESTADOS_ACUER_PAG_ENTREG, "COD_ESTADO_ACUERDO", "DESCRIPCION");
            ViewBag.COD_TIPO_ACUERDO = new SelectList(db.TIPOS_ACUERDO, "COD_TIPO_ACUERDO", "DESRIPCION");
            return View();
        }

        // POST: ACUERDOS_PAGO_ENTREGAB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ACUERDO_PAGO,COD_TIPO_ACUERDO,COD_CARTERA,UserName,DESCRIPCION,COD_ESTADO_ACUERDO,FECHA_REGISTRO,FECHA_ACUERDO,APROBADO,COMENTARIOS,VALOR")] ACUERDOS_PAGO_ENTREGAB aCUERDOS_PAGO_ENTREGAB)
        {
            if (ModelState.IsValid)
            {
                db.ACUERDOS_PAGO_ENTREGAB.Add(aCUERDOS_PAGO_ENTREGAB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "UserName", aCUERDOS_PAGO_ENTREGAB.COD_CARTERA);
            ViewBag.COD_ESTADO_ACUERDO = new SelectList(db.ESTADOS_ACUER_PAG_ENTREG, "COD_ESTADO_ACUERDO", "DESCRIPCION", aCUERDOS_PAGO_ENTREGAB.COD_ESTADO_ACUERDO);
            ViewBag.COD_TIPO_ACUERDO = new SelectList(db.TIPOS_ACUERDO, "COD_TIPO_ACUERDO", "DESRIPCION", aCUERDOS_PAGO_ENTREGAB.COD_TIPO_ACUERDO);
            return View(aCUERDOS_PAGO_ENTREGAB);
        }

        // GET: ACUERDOS_PAGO_ENTREGAB/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACUERDOS_PAGO_ENTREGAB aCUERDOS_PAGO_ENTREGAB = db.ACUERDOS_PAGO_ENTREGAB.Find(id);
            if (aCUERDOS_PAGO_ENTREGAB == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "UserName", aCUERDOS_PAGO_ENTREGAB.COD_CARTERA);
            ViewBag.COD_ESTADO_ACUERDO = new SelectList(db.ESTADOS_ACUER_PAG_ENTREG, "COD_ESTADO_ACUERDO", "DESCRIPCION", aCUERDOS_PAGO_ENTREGAB.COD_ESTADO_ACUERDO);
            ViewBag.COD_TIPO_ACUERDO = new SelectList(db.TIPOS_ACUERDO, "COD_TIPO_ACUERDO", "DESRIPCION", aCUERDOS_PAGO_ENTREGAB.COD_TIPO_ACUERDO);
            return View(aCUERDOS_PAGO_ENTREGAB);
        }

        // POST: ACUERDOS_PAGO_ENTREGAB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ACUERDO_PAGO,COD_TIPO_ACUERDO,COD_CARTERA,UserName,DESCRIPCION,COD_ESTADO_ACUERDO,FECHA_REGISTRO,FECHA_ACUERDO,APROBADO,COMENTARIOS,VALOR")] ACUERDOS_PAGO_ENTREGAB aCUERDOS_PAGO_ENTREGAB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCUERDOS_PAGO_ENTREGAB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_CARTERA = new SelectList(db.CARTERA, "COD_CARTERA", "UserName", aCUERDOS_PAGO_ENTREGAB.COD_CARTERA);
            ViewBag.COD_ESTADO_ACUERDO = new SelectList(db.ESTADOS_ACUER_PAG_ENTREG, "COD_ESTADO_ACUERDO", "DESCRIPCION", aCUERDOS_PAGO_ENTREGAB.COD_ESTADO_ACUERDO);
            ViewBag.COD_TIPO_ACUERDO = new SelectList(db.TIPOS_ACUERDO, "COD_TIPO_ACUERDO", "DESRIPCION", aCUERDOS_PAGO_ENTREGAB.COD_TIPO_ACUERDO);
            return View(aCUERDOS_PAGO_ENTREGAB);
        }

        // GET: ACUERDOS_PAGO_ENTREGAB/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACUERDOS_PAGO_ENTREGAB aCUERDOS_PAGO_ENTREGAB = db.ACUERDOS_PAGO_ENTREGAB.Find(id);
            if (aCUERDOS_PAGO_ENTREGAB == null)
            {
                return HttpNotFound();
            }
            return View(aCUERDOS_PAGO_ENTREGAB);
        }

        // POST: ACUERDOS_PAGO_ENTREGAB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ACUERDOS_PAGO_ENTREGAB aCUERDOS_PAGO_ENTREGAB = db.ACUERDOS_PAGO_ENTREGAB.Find(id);
            db.ACUERDOS_PAGO_ENTREGAB.Remove(aCUERDOS_PAGO_ENTREGAB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

		//Aca inicia syncfusion

        //Traer data

        //Ejemplo vista index auto generado
		public ActionResult UrlAdaptor()
        {
            var DataSource2 = db.ACUERDOS_PAGO_ENTREGAB.ToList();
            ViewBag.dataSource2 = DataSource2;
            return View();
        }	

		public ActionResult GetOrderData(DataManager dm)
        {
            IEnumerable DataSource = db.ACUERDOS_PAGO_ENTREGAB.ToList();
            DataOperations ds = new DataOperations();
            List<string> str = new List<string>();
            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
			if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = ds.PerformSearching(DataSource, dm.Search);
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = ds.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = ds.PerformWhereFilter(DataSource, dm.Where, dm.Where[0].Operator);
            }
            if (dm.Aggregates != null)
            {
                for (var i = 0; i < dm.Aggregates.Count; i++)
                    str.Add(dm.Aggregates[i].Field);
               
            }
            IEnumerable aggregate = ds.PerformSelect(DataSource, str);
            var count = DataSource.Cast<ACUERDOS_PAGO_ENTREGAB>().Count();
            if (dm.Skip != 0)
            {
                DataSource = ds.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = ds.PerformTake(DataSource, dm.Take);
            }
            return Json(new { result = DataSource, count = count}, JsonRequestBehavior.AllowGet);     
        }

        //Perform file insertion 
        public ActionResult PerformInsert(EditParams_ACUERDOS_PAGO_ENTREGAB param)
        {
            DateTime hoy = DateTime.Today;
            param.value.FECHA_REGISTRO = hoy;
            db.ACUERDOS_PAGO_ENTREGAB.Add(param.value);
            //Si tipo acuerdo es interno, enviar correo electrónico con el faltante
            
            db.SaveChanges();
			var data = db.ACUERDOS_PAGO_ENTREGAB.ToList();
			var value = data.Last();
            if (param.value.COD_TIPO_ACUERDO == 1)
            {
                //Crear usuario temporal

                string retornar=crear_usuario_temp(data.Last().COD_ACUERDO_PAGO);

                //Traer atributos para correo
                VISTA_GESTION_CARTERA cart = db.VISTA_GESTION_CARTERA.Single(o => o.COD_CARTERA == param.value.COD_CARTERA);
                CONTRATO_PROYECTO cont_pro = db.CONTRATO_PROYECTO.Single(o => o.COD_CONTRATO_PROYECTO == cart.COD_CONTRATO_PROYECTO);
                CONTRATOS cont = db.CONTRATOS.Single(o => o.COD_CONTRATO == cont_pro.COD_CONTRATO);
                CLIENTES cli = db.CLIENTES.Single(o => o.COD_CLIENTE == cont.COD_CLIENTE);
                PROYECTOS pro = db.PROYECTOS.Single(o => o.COD_PROYECTO == cont_pro.COD_PROYECTO);
                
                //Mensaje de correo electrónico
                string correo = "";
                correo = @"<p>Cordial saludo,</p>";
                correo = correo + @"<p>De acuerdo con la información recibida se ha creado un compromiso de entrega para el cliente <b>"
                       + cli.DESCRIPCION + @"</b> y proyecto <b>"
                       + pro.DESCRIPCION + @"</b> para suministrar el siguiente entregable: </p>"
                       + @"<p><b>Entregable</b>:" + param.value.DESCRIPCION + "</p>"
                       + @"<p><b>Fecha de entrega</b>:" + param.value.FECHA_ACUERDO.ToString() + "</p>"
                       + @"<p><b>Comentarios adicionales</b>:" + param.value.COMENTARIOS + "</p>"
                       + @"<p><b>Centro de costos</b>:" + cont_pro.CENTRO_COSTOS + "</p>"
                       + @"<p><b>Número factura</b>:" + cart.NUMERO_FACTURA + "</p>"
                       + @"Una vez cumplida la entrega, por favor registre los documentos entregables ingresando al siguiente link:"
                       + @"<p><b>link</b>:http://104.196.158.138/BOCHICA/</p>"
                       + @"<p><b>usuario</b>:" + "TEMPORAL_" + data.Last().COD_ACUERDO_PAGO.ToString() + "</p>"
                       + @"<p><b>password</b>:" + retornar + @"</p>"
                       + @"<p>Cordial saludo,</p>"
                       + @"<p>Equipo de gestión de cartera PAYC</p>";
                       

                Email.EnviarEmailHtml("smtp.gmail.com", 587, "centro.costo.estado.payc@gmail.com",
                        "1234payc", "centro.costo.estado.payc@gmail.com",
                        cont_pro.CORREO_RESPONSABLE, "Compromiso entregables - " + cont_pro.CENTRO_COSTOS + " - " + pro.DESCRIPCION,correo);
            }
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        //Actualizar grid
        public ActionResult PerformUpdate(EditParams_ACUERDOS_PAGO_ENTREGAB param)
        {
            
			ACUERDOS_PAGO_ENTREGAB table = db.ACUERDOS_PAGO_ENTREGAB.Single(o => o.COD_ACUERDO_PAGO == param.value.COD_ACUERDO_PAGO);

            db.Entry(table).CurrentValues.SetValues(param.value);
            db.SaveChanges();
			return RedirectToAction("GetOrderData");
			
        }

        //Función que crea el usuario temporal asociado al compromiso del entregable
        public string crear_usuario_temp(long COD_ACUERDO_PAGO)
        {
            
            //Variables de gestión de usuarios con la clase owin
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //Crear rol temporal entregables si no existe   
            if (!roleManager.RoleExists("temporal"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "temporal";
                roleManager.Create(role);

            }

            //Crear el usuario temporal
            var user = new ApplicationUser();
            user.UserName = "TEMPORAL_"+COD_ACUERDO_PAGO.ToString();
            user.Email = "director.analitica@payc.com.co";
            Random rand = new Random(DateTime.Now.Millisecond);
            string userPWD = rand.Next(100000000, 999999999).ToString();

            var chkUser = UserManager.Create(user, userPWD);

            //Add default User to Role Admin   
            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, "temporal");

            }

            return userPWD;
        }

        //Almacenar archivo entregables
        [AcceptVerbs("Post")]
        public void Save_entregables()
        {
            
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Length > 0)
            {
                // Get the files using the name attribute as a key. 
                var httpPostedFile = System.Web.HttpContext.Current.Request.Files["CARGUE_ARCHIVOS"];

                if (httpPostedFile != null)
                {
                    var fileSave = System.Web.HttpContext.Current.Server.MapPath("entregables");
                    if (!Directory.Exists(fileSave))
                    {
                        Directory.CreateDirectory(fileSave);
                    }

                    var fileSavePath = Path.Combine(fileSave, httpPostedFile.FileName);

                    //Almacenaje de datos entretable en tabla entregables
                    var user = User.Identity;
                    ApplicationDbContext context = new ApplicationDbContext();
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    var s = UserManager.GetRoles(user.GetUserId());
                    ViewBag.Rol = s[0].ToString();
                    string cod_compromiso_string = user.Name.ToString().Replace("TEMPORAL_", "");
                    int i = 0;
                    if (!Int32.TryParse(cod_compromiso_string, out i))
                    {
                        i = -1;
                    }
                    long ii = (long)i;
                    db.GESTION_ENTREGABLES.RemoveRange(db.GESTION_ENTREGABLES.Where(x => x.COD_ACUERDO_PAGO == ii));
                    
                    GESTION_ENTREGABLES gest = new GESTION_ENTREGABLES();
                    gest.COD_ACUERDO_PAGO = ii;
                    gest.URL_ARCHIVO = httpPostedFile.FileName.Replace(" ", "%20");
                    DateTime hoy = DateTime.Today;
                    gest.FECHA_CARGA = hoy;
                    
                    db.GESTION_ENTREGABLES.Add(gest);
                    ACUERDOS_PAGO_ENTREGAB gest1 = db.ACUERDOS_PAGO_ENTREGAB.Single(o => o.COD_ACUERDO_PAGO == ii);
                    gest1.COD_ESTADO_ACUERDO = 2;

                    db.SaveChanges();
                    
                    if (!System.IO.File.Exists(fileSavePath))
                    {    /*To save files at server*/
                        httpPostedFile.SaveAs(fileSavePath);
                        HttpResponse Response = System.Web.HttpContext.Current.Response;
                        Response.Clear();
                        Response.ContentType = "application/json; charset=utf-8";
                        Response.StatusDescription = "Archivo cargado exitosamente";
                        Response.Write(httpPostedFile.FileName);
                        Response.End();
                    }
                    else
                    {
                        HttpResponse Response = System.Web.HttpContext.Current.Response;
                        Response.Clear();
                        //Aca va el tratamiento para duplicados
                        //Response.Status = "400 ya existe un archivo con el mismo nombre, por favor renombrelo";
                        //Response.StatusCode = 400;
                        Response.ContentType = "application/json; charset=utf-8";
                        Response.StatusDescription = "Ya existe un archivo con el mismo nombre";
                        Response.Write(httpPostedFile.FileName);
                        Response.End();

                    }
                }
            }
        }

        //Eliminar Archivo entregables
        public ActionResult remove_entregables(string fileNames)
        {
            try
            {
                var fileSave = System.Web.HttpContext.Current.Server.MapPath("entregables");

                //var fileName = System.Web.HttpContext.Current.Request.Files["CARGUE_ARCHIVOS"].FileName;
                var fileSavePath = Path.Combine(fileSave, fileNames);
                if (System.IO.File.Exists(fileSavePath))
                {
                    System.IO.File.Delete(fileSavePath);
                }

                return Json("SI", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json("SI", JsonRequestBehavior.AllowGet);
            }
        }

        //Borrar grid
        public ActionResult PerformDelete(int key, string keyColumn)
        {
            db.ACUERDOS_PAGO_ENTREGAB.Remove(db.ACUERDOS_PAGO_ENTREGAB.Single(o => o.COD_ACUERDO_PAGO == key));
            db.SaveChanges();
            return RedirectToAction("GetOrderData");

        }
    }
}
