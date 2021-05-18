using DevFramework.Core.CrossCutingConcerns.cacheng;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspect.PostSharp.CacheAspect
{
    [Serializable]
   public class CacheRemoveAspect: OnMethodBoundaryAspect
    {
        private string _pattern;

        public CacheRemoveAspect(string pattern,Type cachetype)
        {
            _pattern = pattern;
            _cachetype = cachetype;
        }

        private Type _cachetype;

        public CacheRemoveAspect(Type cachetype)
        {
            _cachetype = cachetype;
        }

        private ICacheManager _cacheManager;

        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cachetype) == false)
            {
                throw new Exception("wrong Cache Manager");
            }

            _cacheManager = (ICacheManager)Activator.CreateInstance(_cachetype);//snıf örneği oluştur
            base.RuntimeInitialize(method);
        }

        //ürün güncellendiğinde yada silindiğinde bizim cache i kaldırmamız lazım ekleme silme güncelleme operasyonu başarılı odluğunda bizim cache den datayı 
        //silmemiz gerekiyor
        public override void OnSuccess(MethodExecutionArgs args) // method başarılı olduğunda 
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern) ? string.Format("{0}.{1}.*",args.Method.ReflectedType.Namespace,args.Method.ReflectedType.Name):_pattern);// {0}=namespace {1}=class * ise herşey demek
            //sonda eğer pattern varsa onu yaz dedik
        }
    }
}
