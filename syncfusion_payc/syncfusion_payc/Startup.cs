#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using syncfusion_payc.Models;

using System.Security.Claims;

[assembly: OwinStartupAttribute(typeof(syncfusion_payc.Startup))]
namespace syncfusion_payc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // Se crea el usuario y rol admin
            if (!roleManager.RoleExists("Admin"))
            {

                // Se crea el rol admin
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Se crea el usuario administrador                  

                var user = new ApplicationUser();
                user.UserName = "ADMIN";
                user.Email = "director.analitica@payc.com.co";

                string userPWD = "Analitica_Payc2021*";

                var chkUser = UserManager.Create(user, userPWD);

                //Crear Usuario Admin 
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            //  Crear rol comercial   
            if (!roleManager.RoleExists("Comercial"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Comercial";
                roleManager.Create(role);

            }

            // Crear rol financiera  
            if (!roleManager.RoleExists("Financiera"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Financiera";
                roleManager.Create(role);

            }
            // Crear rol recurso humano
            if (!roleManager.RoleExists("RRHH"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "RRHH";
                roleManager.Create(role);

            }
            // Crear rol Directivo
            if (!roleManager.RoleExists("Directivo"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Directivo";
                roleManager.Create(role);

            }


        }
    }
}
