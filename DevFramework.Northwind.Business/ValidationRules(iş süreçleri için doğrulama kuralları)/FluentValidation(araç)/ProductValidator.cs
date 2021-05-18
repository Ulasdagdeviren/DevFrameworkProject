using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Entities.Concrete;
using FluentValidation;

namespace DevFramework.Northwind.Business.ValidationRules_iş_süreçleri_için_doğrulama_kuralları_.FluentValidation_araç_
{
  public class ProductValidator:AbstractValidator<Product>
    {
        //  Biz aşşağıda yazdığımız validasyonu sürekli olarak biryerlerden çağırıyor olmamız gerekiyor buna bağlı olarak 
        //  Core katmanına bir tane tool yazılır crooscutingconsorns dosyasına bir validatortool yazdık
        public ProductValidator()  
        {
            RuleFor(p => p.CategoryId).NotEmpty(); //CategoryId kesinlikle girilmeli  NotEmpty().WithMassage("") kendi mesajımızı yazabiliriz   
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0); //unitprice 0 dan büyük mü
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).Length(2,20);//max min
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryId == 1);
           // RuleFor(p => p.ProductName).Must(StartWithA);//uyduruk bir kural
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
