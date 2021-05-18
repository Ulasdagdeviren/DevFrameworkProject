using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DevFramework.Core.CrossCutingConcerns.Security.Web;
using DevFramework.Core.Utilities.Mvc.infrastructure;
using DevFramework.Northwind.Business.DapendencyResolvels.Ninject;

namespace DevFrameworks.Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModüle(),new AutoMapperModule())); // kendimiz yazdık
            // yani burda da controllerfactory nin ninjectcontrollerfactory olduğu söylemiş olduk

                                                                                 // her istek yapıldğında kişinin kullanıcı bilgilerinin cookie den çekiillmesi ve identity bilgisinin okunması
        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest; // postAuthenticatetRequest=kimlik doğrulama isteği
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e) // kişinin Authanticasyon bilgilerinin erişilebilir olduğu zamana karşılık gelir
        {
            try // Hackeleme olursa sonlandırmak için sisteme hata vermesini engellmiş luruz
            {
                var authcookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authcookie == null)
                {
                    return; // hiç uğraşma sonlarndır
                }

                var encTicked = authcookie.Value;
                if (String.IsNullOrEmpty(encTicked))  // elle oluşturlmuş veya boş olablir kontrol yaptık
                {
                    return;
                }

                var ticked = FormsAuthentication.Decrypt(encTicked); // çözmemiz lazım kiöi encTicked ıcon
                var securityUtilities = new SecurityUtilities();
                var identity = securityUtilities.FormAuthTicketIdentity(ticked);// identity oluşturduk
                var principle = new GenericPrincipal(identity, identity.Roles);
                HttpContext.Current.User = principle;
                Thread.CurrentPrincipal = principle;// backendde de erişim sağlaık yani business da
            }
            catch (Exception)
            {
                
            }
         

        }
    }                                                     // web de kendimizi hep tanıtmamız lazım
}
