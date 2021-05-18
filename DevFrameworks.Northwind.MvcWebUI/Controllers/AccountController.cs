using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DevFramework.Core.CrossCutingConcerns.Security.Web;
using DevFramework.Northwind.Business.Abstract;

namespace DevFrameworks.Northwind.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }

        // GET: Account
        public string Login(string userName, string password) // tamamen test amaçlı string döndürdük normalde bir login ekaraı açmalı ve onu post etmeliyiz
        {
            var user = _service.GetByUserNameAndPassword(userName, password);
            if (user != null)
            {
                AuthenticationHelper.CreateAuthCookie(
                    new Guid(),
                    user.UserName,
                    user.Email,
                    DateTime.Now.AddDays(15),
                    _service.GetUserRoles(user).Select(u => u.RoleName).ToArray() // array döner
                    , false,
                    user.FirstName,
                    user.LastName);
                //  new Guid(),
                //  "engindemirog",
                // "engindemirog@gmail.com,",
                //DateTime.Now.AddDays(15),
                //new[] { "admin" }, false,
                ////"ulas",
                //"dagdeviren");   // AuthenticationHelper ı nasıl kullancaz
                return "User is authenticated!";
            }

            return "User is not authenticated"; // kullanıcı yoksa yetki yok
        }
    }
}