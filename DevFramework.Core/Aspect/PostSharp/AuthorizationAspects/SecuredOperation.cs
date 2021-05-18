using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspect.PostSharp.AuthorizationAspects
{[Serializable]                                                         //İsAuthorrized = yetkilendirildi
    public class SecuredOperation:OnMethodBoundaryAspect // method başlayınca devreye girecek
    { // currentprincipal =.netframework ile herhangi bir uygulama bağımsız mevcut kulllanıcalı ve bu kullanıclara ait bilgileri tutabildiğimiz rol bazlı güvenlik sistemidir
        public string Roles { get; set; }// rolleri buraya atadık
        //authorization=yetki demektir
        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(','); // gelenler bir dizi gibi olucak
            bool İsAuthorrized = false;
            for (int i = 0; i < roles.Length; i++) // bütün rolleri gez
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))// currenPrincable veritaanından çekicez bunları benim gönderdiğim herhangi bir role sahipse,
                {                                                               // currentprincale rollerinde [i] admin var mı vs diye kontrol
                    İsAuthorrized = true; // eğer kullanıcımız admin veya editor rolüne sahipse
                }

            }

            if (İsAuthorrized==false)
            {
                throw new SecurityException("you are not authorized");// güvenlik hatası
            }
            
        }
    }
}
