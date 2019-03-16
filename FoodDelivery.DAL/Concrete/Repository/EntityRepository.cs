using FoodDelivery.DAL.Abstract.IRepository;
using FoodDelivery.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Repository
{
    //Repository de bağlantı için de generic kullandık. Burada Where TContext:DbContext kısıtını kullanmazsanız, program TContext'in bağlantı nesnesi olduğunu algılamaz hata verir. Bu kısıtlamalar bir nevi verilen Generic ifadenin ne tipte bir generic ifade olduğunu programa söyler, program da buna göre hareket eder. 
    public class EntityRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        TContext db;
        object _lockObject = new object();

        public EntityRepository()
        {
            lock (_lockObject)
            {
                if (db == null)
                {
                    db = new TContext();
                }
            }
        }

        public void Add(TEntity entity)
        {
            var addEntity = db.Entry(entity);
            addEntity.State = EntityState.Added;
            DbSave(db);
        }

        public void DeleteByEntity(TEntity entity)
        {
            var deleteEntity = db.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            DbSave(db);
        }

        public void DeleteByID(int id)
        {
            var deleteEntity = db.Entry(GetByID(id));
            deleteEntity.State = EntityState.Deleted;
            DbSave(db);
        }

        public ICollection<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }


        public TEntity GetByID(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetEntitiesByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return db.Set<TEntity>().Where(filter);
        }

        public void Update(TEntity entity)
        {
            var updateDatabase = db.Entry(entity);
            updateDatabase.State = EntityState.Modified;
            DbSave(db);
        }

        public void DbSave(DbContext db)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
