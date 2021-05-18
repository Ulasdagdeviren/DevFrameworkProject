using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCutingConcerns.cacheng
{
   public interface ICacheManager
   { // alttaki getin içindeki t dıştaki t nin ne olduğunu söyler o almazsa hata verir üstte belirtmemizi ister
       T Get<T>(string key); //ben sana bir key vericem o key e göre cache datasını getir yani bir her cash datasına bir isim vermemiz gerekiyor onuda key ile veririz
       void Add(string key, object data, int cacheTime);//cacheTime cache de data ne kadar kalacak void dedik çünkü çalıştığımız altyapı belli değil
       bool IsAdd(string key); //daha önce eklenmiş mi 
       void Remove(string key);
       void RemoveByPattern(string pattern);
       void Clear();

   }
}
