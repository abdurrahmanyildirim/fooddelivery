using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Ninject
{
    public class InstanceFactory
    {
        //Burada GetInstance adında bir method yazıyoruz, static ve Generic olmasına dikkat ediyoruz yoksa yaptığımız şeyin hiç bir anlamı kalmaz.
        public static T GetInstance<T>()
        {
            //new StandardKernel class'ına az önce yazdığımız DalModule class'ını gönderiyoruz, StandardKernel class'ı bizim kurduğumuz mantığa göre gidip DalModule içerisinden bir Instance alıyor bunu da bize o instance türünden döndürüyor.
            var kernel = new StandardKernel(new DalModule());
            return kernel.Get<T>();
        } 
    }
}
