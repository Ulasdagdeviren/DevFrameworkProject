using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace DevFramework.Core.Utilities.Mappings
{
   public class AutoMapperHelper
    {
       public static List<T> MapToSameTypeList<T>(List<T> list) // Generic bir mapper yapmış olduk
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<T, T>(); // product ile prodcut map edeeck sistemi ayağa kaldır
            }); // öncelikle mapping kurallarını belirlememiz gerekiyor
            List<T> result = Mapper.Map<List<T>, List<T>>(list); // listeyi map etmek istiyrouz
            return result;
        }
       public static T MapToSameType<T>(T obj) // burda farklı şeyler de yapabliriz mesela productı producta çevirmek gibi
       {
           Mapper.Initialize(c =>
           {
               c.CreateMap<T, T>(); 
           }); 
           T result = Mapper.Map<T, T>(obj);
           return result;
       }
    }
}
