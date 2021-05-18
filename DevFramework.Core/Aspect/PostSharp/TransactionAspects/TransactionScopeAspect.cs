using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspect.PostSharp.TransactionAspects
{                                     // TransactionScope işlem kendisiyle etkileşime girmeden hata alınırsa bitir
    [Serializable]                   // örneğin bankada havale yapıcaz gönderme başarılı hesap güncellendi ancak karıya gitmedi para geri gelicek yani işlem tamamlanmayacak 1 başarılı 2 başarılı ama 3 hatalı hepsi baştan başlamasın diye yazdık
    public  class TransactionScopeAspect:OnMethodBoundaryAspect     
  {
      private TransactionScopeOption _option; // TransactionscopeOption : İşlem kapsamı oluşturmak için ek seçenekler sağlar.


        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionScopeAspect()
        {
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag=new TransactionScope(_option);
            
        }

        public override void OnSuccess(MethodExecutionArgs args) // method başarılı olduğunda try başarılı olduğunda
        {
            ((TransactionScope)args.MethodExecutionTag).Complete(); // Executing=Yürütme demektir
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
  }
}
