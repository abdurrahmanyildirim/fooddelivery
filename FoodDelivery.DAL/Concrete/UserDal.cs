using FoodDelivery.DAL.Abstract;
using FoodDelivery.DAL.Concrete.Repository;
using FoodDelivery.Entities;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FoodDelivery.DAL.Concrete
{
    //IUserDal interface'i ve UserDal class'ını örnek olsun diye yazdım. Oluşturduğumuz her class'ın bir interface'i olmak zorunda ve isimlendirmeleri de bu şekilde olmalıdır. Oluşturduğumuz interface'e IRepository'yi implemente edin daha sonra Class'a EfRepository'yi miras verin ve interface'i implement edin. EfRepository generic bir yapı olduğu için sizden class ve bağlantı türünü isteyecektir, bunun için Class türünü ve bizim bağlantımız olan Context'i yazmayı unutmayın.
    public class UserDal : EntityRepository<User, Context>, IUserDal
    {
        //Dal katmanında ortak olmayan metotlar yazdığınız zaman önce interface'e yazın daha sonra oradan İmplement edin.  
        public IQueryable<User> GetNameByFilter(string filter)
        {
            //EfRepository'de oluşturduğumuz GetAEntitiesByFilter() metodunu aşağıdaki gibi çağırıp bunu özel sorgularda kullanabiliriz.
            
            return GetEntitiesByFilter(x => x.FirstName.StartsWith(filter));
        }

        public User GetUserByCookie(string cookie)
        {
            return GetEntitiesByFilter(x => x.Cookie == cookie).FirstOrDefault();
        }

        public User GetUserByLogin(string userName, string password)
        {
            return GetEntitiesByFilter(x => x.Email == userName && x.Password == password).FirstOrDefault();
        }

        public User Get()
        {
            Context db = new Context();
            return db.Users.Include(x => x.Addresses).FirstOrDefault();
        }
    }
}
