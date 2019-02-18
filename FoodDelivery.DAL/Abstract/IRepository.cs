using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Abstract.IRepository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        IQueryable<T> GetEntitiesByFilter();
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void DeleteByEntity(T entity);
        void DeleteByID(int id);
    }
}
