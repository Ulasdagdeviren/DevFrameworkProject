using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using DevFramework.Core.CrossCutingConcerns.Validation.FluentValidation;
using DevFramework.Entities.Concrete;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules_iş_süreçleri_için_doğrulama_kuralları_.FluentValidation_araç_;
using DevFramework.Northwind.DataAcsess.Abstract;
using FluentValidation.Resources;
using DevFramework.Core.Aspect.PostSharp;
using DevFramework.Core.Aspect.PostSharp.AuthorizationAspects;
using DevFramework.Core.Aspect.PostSharp.TransactionAspects;
using DevFramework.Core.Aspect.PostSharp.ValidationAscpets;
using DevFramework.Core.DataAcsess;
using DevFramework.Core.Aspect.PostSharp.CacheAspect;
using DevFramework.Core.Aspect.PostSharp.LogAspects;
using DevFramework.Core.Aspect.PostSharp.PerformanceCounterAspect;
using DevFramework.Core.CrossCutingConcerns.cacheng.Microsoft;
using DevFramework.Core.CrossCutingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.Utilities.Mappings;
using PostSharp.Aspects.Dependencies;

namespace DevFramework.Northwind.Business.Concrete.Managers  // loglama= kim bu bilgiyi hangi parametrelerle kim ne zamn çalıştırdı bilgisi tutarız
{
   // [LogAspect(typeof(DatabaseLogger))]  Assembly infoya yazdım böylelikle sadece bu manager değil diğerleride loglanır
    [LogAspect(typeof(FileLogger))]  // ikisi ile birlikte bütün metodlar loglanacaktır
   public class ProductManager:IProductService   // validation = bir nesnenein format olarak uyumluluk anlmaına gelir örneğin bir ürün nesnesi için ürün ismini girmek ürün ismini en az 3 karakter girmek vs
   {
       private IProductDal _productDal;

       private readonly IMapper _mapper;
       //private readonly IQueryableRepository<Product> _queryable;

       public ProductManager(IProductDal productDal,IMapper mapper) //,(IQueryableRepository<Product> queryable) yazabiliriz productdalın yanına yazılır
       {
           _productDal = productDal;
           _mapper = mapper;
           //_queryable = queryable;
       }
        [CacheAspect(typeof(MemoryCacheManager),60)]
       // [LogAspect(typeof(DatabaseLogger))] 
       // [LogAspect(typeof(FileLogger))]
       [PerformanceCounterAspect(2)] // bizim için özel olaan methodlar varsa böyle yazarız
      // [SecuredOperation(Roles="Admin,Editor,Student")] // sadece admin görebilsin demektir ya da editör de ekle
       public List<Product> GetAll()
       {
           // Web api burda yani entityframework de serileştirilemez o yüzden Automapper kullanıcaz 6.1.1 sürümünü
           //_queryable.Table.vs
         /*  Thread.Sleep(3);*/// bunu dersek 3 saniye bekler ve output ekranında performance kaybını gösteren yazı görünür
         //  return _productDal.GetList();
         var products = _mapper.Map<List<Product>>(_productDal.GetList()); //AutoMapperHelper.MapToSameTypeList(_productDal.GetList()); bunu değiştirdik yani AutoMapperHelper kullanımını bıraktık ninject,profile common yazıldı
         return products;
       }

      

       public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProdcutId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]  //alttakiler yerine bunlar kullanılır
       // [CacheRemoveAspect(typeof(MemoryCacheManager))] // ürünle ilgili tüm cache leri silmeye yarar
       // [LogAspect(typeof(FileLogger))]
        public Product Add(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(),product);
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidator))] // Burada productvalidator tipi ile çalışıcaz dedik
        public Product Update(Product product)
        {
            //ValidatorTool.FluentValidate(new ProductValidator(), product); bunu buraya yazmak solidin single of responsblity ilkesine aykırıdır çünkü bu ilke derki manager da sadece iş kodları yazılır onun dışında farklı kodlar yazamayız
            return _productDal.Update(product);
        }
      [TransactionScopeAspect]
      [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product product, Product product2)
        {
            _productDal.Add(product);
            //Busiiness code
            _productDal.Update(product2);



            //using (TransactionScope scope=new TransactionScope())
            //{
            //    try
            //    {
            //       _productDal.Add(product);
            //     //Busiiness code
            //      _productDal.Update(product2);
            //      scope.Complete();
            //    }
            //    catch 
            //    {
            //        scope.Dispose();
            //    }
            //}

        }

        
   }
}
