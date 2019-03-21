using FoodDelivery.DAL.Abstract;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Ninject
{
    //Ninject bir framework'dür. Bu kütüphane sayesinde FactoryDesign'ı sağlamış oluyoruz ve uygulama içinde alacağımız bütün instance'ları bu ninject modülüyle sağlayacağız. Tabi burada kendi koyduğumuz kurallara göre instance'ların alınmasını sağlayacağız. Üstelik bu kütüphane sayesinde depency injection yani bağımlılıkları soyutlandırmayı da sağlamış oluyoruz.
    //Burada yaptığımız işlemler, DalModule adında bir class oluşturuyoruz. Daha sonra nuget package'dan Ninject kütüphanesini indiriyoruz. Kütüphaneyi indirdikten sonra NinjectModule class'ını kendi DalModule class'ımıza miras veriyoruz. bunları yaptıktan sonra Load() methodunu override ediyoruz.
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            //Bütün yapı kurulduktan sonra burada Bind olan yere göndereceğimiz interface'i yazıyoruz ve To kısmına ise bize üretmesini istediğimiz nesneyi yazıyoruz. Daha sonra eğer isterseniz sonuna da bizim aşağıda yazdığım gibi singleton eklerseniz Singleton dizayn uygulanmış oluyor.

            Bind<IUserDal>().To<UserDal>().InSingletonScope();
            Bind<ICompanyApplyDal>().To<CompanyApplyDal>().InSingletonScope();
            Bind<ICompanyDal>().To<CompanyDal>().InSingletonScope();
            Bind<IOrderDetailDal>().To<OrderDetailDal>().InSingletonScope();
            Bind<IMenuDal>().To<MenuDal>().InSingletonScope();
            Bind<IOrderDal>().To<OrderDal>().InSingletonScope();
            Bind<IContactDal>().To<ContactDal>().InSingletonScope();
            Bind<IAddressDal>().To<AddressDal>().InSingletonScope();
            Bind<IRegionDal>().To<RegionDal>().InSingletonScope();
            Bind<IReviewDal>().To<ReviewDal>().InSingletonScope();
            Bind<IBranchDal>().To<BranchDal>().InSingletonScope();
        }
    }
}
