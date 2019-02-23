using FoodDelivery.DAL.Abstract;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Ninject
{
    //Ninject bir framework'dür. Bu kütüphane sayesinde FactoryDesign'ı sağlamış oluyoruz ve uygulama içinde alacağımız bütün instance'ları bu ninject modülüyle sağlayacağız. Tabi burada kendi koydğumuz kurallara göre instance'ların alınmasını sağlayacağız. Üstelik bu kütüphane sayesinde depency injection yani bağımlılıkları soyutlandırmayı da sağlamış oluyoruz.
    //Burada yaptığımız işlemler, DalModule adında bir class oluşturuyoruz. Daha sonra nuget package'dan Ninject kütüphanesini indiriyoruz. Kütüphaneyi indirdikten sonra NinjectModule class'ını kendi DalModule class'ımıza miras veriyoruz. bunları yaptıktan sonra Load() methodunu override ediyoruz.
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            //Bütün yapı kurulduktan sonra burada Bind olan yere göndereceğimiz interface'i yazıyoruz ve To kısmına ise bize üretmesini istediğimiz nesneyi yazıyoruz. Daha sonra eğer isterseniz Sonuna da benim aşağıda yazdığım gibi singleton eklerseniz Singleton dizayn uygulanmış oluyor. Devamını instance factory'de yazacağım.
            Bind<IUserDal>().To<UserDal>().InSingletonScope();
            Bind<ICompanyApplyDal>().To<CompanyApplyDal>().InSingletonScope();
        }
    }
}
