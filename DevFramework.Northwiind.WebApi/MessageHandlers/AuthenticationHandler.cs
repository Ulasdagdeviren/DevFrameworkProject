using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DapendencyResolvels.Ninject;

namespace DevFramework.Northwiind.WebApi.MessageHandlers
{
    public class AuthenticationHandler:DelegatingHandler // bu bir message handler o yüzden degateting handlerden implement edilmeli
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault(); // token =jeton demek
                if (token!=null)
                {
                    byte[] data = Convert.FromBase64String(token);// Base 64 ü normal stringe çeviriyor olucaz
                    string decodedString = Encoding.UTF8.GetString(data); //decoded String=kodu çözlmüş dize demektir
                    string[] tokenValues = decodedString.Split(':'); // Authorization ticked ı string şeklinde olmalı

                    IUserService userService = InstanceFactory.GetInstance<IUserService>();// bize IUserService türünde Business modül den bir çözüm ver yani bana UserManagerı verecek kısacası çünkü Bind ile birleştirmiştik

                    User user = userService.GetByUserNameAndPassword(tokenValues[0], tokenValues[1]);
                    if (user!=null) // burdan bir kullancı dönüyor
                    {
                      IPrincipal principal=new GenericPrincipal(new GenericIdentity(tokenValues[0]),userService.GetUserRoles(user).Select(u=>u.RoleName).ToArray());  // şimdi bu adamın rolleri getirip principle nesnesine basmamız gerekiyor
                      Thread.CurrentPrincipal = principal;// Backend deki identity artık set edilmiş olur burda
                      HttpContext.Current.User = principal; // burası da web apinin kendisi için
                    }
                }
            }
            catch 
            {
               
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}