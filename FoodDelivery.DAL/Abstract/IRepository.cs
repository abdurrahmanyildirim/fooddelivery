using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Abstract.IRepository
{
    public interface IRepository<T>
    {
        ICollection<T> GetAll();
        IQueryable<T> GetEntitiesByFilter(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void DeleteByEntity(T entity);
        void DeleteByID(int id);
    }
}
