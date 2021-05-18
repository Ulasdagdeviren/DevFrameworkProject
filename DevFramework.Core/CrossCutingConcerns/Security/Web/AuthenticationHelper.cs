using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace DevFramework.Core.CrossCutingConcerns.Security.Web
{
   public class AuthenticationHelper // Eğer bir giriş sekmesi oluşşturursak user ve passaword kontrolü burddan doğrulanır çünkü veri tabanında bu gitiçek
    { // kullanııc bilgililerini al şifrele cookie bas özet olarak
        public static void CreateAuthCookie(Guid id,string userName,string email,DateTime exprition,string[] roles,
            bool rememberMe,string firstName,string lastName) // istediğimiz dataları byurada tutuypruz ticket burada cookie olarak şifreli bir şekilde tutuluyor
        {
            var authTicket=new FormsAuthenticationTicket(1,userName,DateTime.Now,exprition,rememberMe,
                CreateAuthTags(email,roles,firstName,lastName,id));// en sondali user data
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,encTicket));
        }

        private static string CreateAuthTags(string email, string[] roles, string firstName, string lastName, Guid id)
        {
          var stringBuilder=new StringBuilder();
          stringBuilder.Append(email);
          stringBuilder.Append("|"); // emaili ayırdığımız şey bu
          for (int i = 0; i < roles.Length; i++)
          {
              stringBuilder.Append(roles[i]);// her rolü yazdırdık
              if (i<roles.Length-1)
              {
                  stringBuilder.Append(",");// rollerin arasına virgül koyduk
              }
          }
          stringBuilder.Append("|");// roler,nde bittiğini söyledik
          stringBuilder.Append(firstName);
          stringBuilder.Append("|");
          stringBuilder.Append(lastName);
          stringBuilder.Append("|");
          stringBuilder.Append(id);
         
          return stringBuilder.ToString();
        }
    }
}
