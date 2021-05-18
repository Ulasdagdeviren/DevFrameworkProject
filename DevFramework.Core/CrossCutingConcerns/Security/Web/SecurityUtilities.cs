using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DevFramework.Core.CrossCutingConcerns.Security.Web
{
  public class SecurityUtilities
    {
        public Identity FormAuthTicketIdentity(FormsAuthenticationTicket ticket)
        {
            var ıdentity=new Identity // coocie yi parçaladık identity yaptık 
            {
                Id = setId(ticket),
                Name = SetName(ticket),
                Email = SetEmail(ticket),
                Roles = SetRoles(ticket),
                FirstName = SetFirstName(ticket),
                LastName = SetLastName(ticket),
                AuthenticationType = SetAuthType(),
                IsAuthenticated = SetIsAuthenTicated()
            };
            return ıdentity;
        }

        private string SetAuthType()
        {
            return "Forms";
        }

        private bool SetIsAuthenTicated()
        {
            return true;
        }

        

        private string SetLastName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[3]; // burda authendication helper da CreateAuthTags(email,roles,firstName,lastName,id)); user data oalrak belirttil 3 .sü bizim için last name dedik
        }

        private string SetFirstName(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }

        private string[] SetRoles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            string[] roles =
                data[1].Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            return roles; // kullanıcı elle yazdığı için 
        }

        private string SetEmail(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[0];
        }

        private string SetName(FormsAuthenticationTicket ticket)
        {
           return ticket.Name;
        }

        private Guid setId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return new Guid(data[4]); 
        }
    }
}
