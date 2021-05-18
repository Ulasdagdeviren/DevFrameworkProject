using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCutingConcerns.cacheng.Microsoft
{
  public class MemoryCacheManager:ICacheManager
    {
        protected ObjectCache Cache  // Cashe nesnesi oluşturduk çünkü aşşağıyı bununla yöneticez
        {
            get { return MemoryCache.Default; } // default=varsayılan deöektir
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];// mevcut Cashe nesnemde yani cashe datalarından bana sana gönderdiğim Key isminde olan Cashe i döndür ve bana ver
        }

        public void Add(string key, object data, int cacheTime=60)//gödermesse 60 olsun
        {
            if (data==null) // Data kontrol Cascleyeceğimiz data yoksa 
            {
                return;
            }
            var  policy=new CacheItemPolicy{AbsoluteExpiration = DateTime.Now+TimeSpan.FromMinutes(cacheTime)}; // Burda bir data oluşturduk cashe eklemek için newden sonrada cashe de data ne kadar dursun bilgisi tutduk Datetim.now şu andan itibaren bana gönderdiğin cashe time kadar tut
            Cache.Add(new CacheItem(key , data), policy);
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase); // Regex e çeviricez önce paterni tek satır halinde gönder , compiled edinmiş = derlenmiş  ,
            var keystoremove = Cache.Where(d => regex.IsMatch(d.Key)).Select(d => d.Key).ToList(); // cashe datasından hangi casheleri silicez koşuluın içince Mach olan yani eşleşenleri cash le yalnız seç çünkü bunları listeye atıcaz
            foreach (var key in keystoremove) // burda da bütün cashleri gezip bu key e sahip olan cashleri bellekten sil 
            {
                Remove(key);
            }
        }

        public void Clear()
        {
            foreach (var Item in Cache) // burda da cashdeki bütün ıtemları ıtem.key ile sil demiş olduk
            {
                Remove(Item.Key);
            }
        }
    }
}
