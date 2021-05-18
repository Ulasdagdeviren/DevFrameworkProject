using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCutingConcerns.cacheng;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspect.PostSharp.CacheAspect
{[Serializable]    //     String Format yöntemi ile değerlerin formatlarının değiştirilmesi sağlanır.  Sayılar, tarihler vb. değerleri farklı biçimlere dönüştürülmesi sağlanır. Geriye formatı değişmiş olan veri döner.
    public class CacheAspect:MethodInterceptionAspect
   {
       private Type _cachetype; // Hangi cache kullanıcağı mem cache memory cache,Redis
       private int _cacheByMinute;
       private ICacheManager _cacheManager;//yukarıdakıler atmak için

       public CacheAspect(Type cachetype, int cacheByMinute)
       {
           _cachetype = cachetype;
           _cacheByMinute = cacheByMinute;
       }

       public override void RuntimeInitialize(MethodBase method) // çalışma : compiletime derleme zamanı demek 
        {
           if (typeof(ICacheManager).IsAssignableFrom(_cachetype)==false) // kişi bana yanlış bir cashe mekanizması gönderebilir burda gönderilen cashe type bir cashe manager türünde değilse 
           {
               throw new Exception("wrong Cache Manager");
           }

           _cacheManager = (ICacheManager) Activator.CreateInstance(_cachetype);//snıf örneği oluştur yani bir ınstance yani göderdiğim herşey cashe manager olduğu için direk atadık
           base.RuntimeInitialize(method);
       }
        // üstte çalıltırlmaya çalışan methodun sonucu cashe de varmı ona bakıcaz alt tarafta
       public override void OnInvoke(MethodInterceptionArgs args) // Method çalıştırlmadan önce args=methodun demek 
       {
           var methodname = string.Format("{0},{1},{2}", args.Method.ReflectedType.Namespace, // çalıştırılacak methodun parametrelerini namespace ni kullanarak bir key oluşturduk
               args.Method.ReflectedType.Name, // class ismine ulaştık burda  reflected=yansıyan demek
               args.Method.Name);
            
           var arguments = args.Arguments.ToList(); // parametrekeye göre cachleme yaptığımız için bunu yazdık
           var key = string.Format("{0},({1})", methodname,
               string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));
           if (_cacheManager.IsAdd(key)) // key cache de var mı diye kontrol ettik
           {
               args.ReturnValue = _cacheManager.Get<object>(key); // o zamn manager den keyi al dedik  returnvalue olaya devam etme bitir

           }

           base.OnInvoke(args);
            _cacheManager.Add(key,args.ReturnValue,_cacheByMinute); // eğer cache de yoksa yaptığımız keyi gönder


       }
   }
}
