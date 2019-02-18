using FoodDelivery.DAL.Abstract.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Concrete.Repository
{
    //Repository de bağlantı için de generic kullandık. Burada Where TContext:DbContext kısıtını kullanmazsanız, program TContext'in bağlantı nesnesi olduğunu algılamaz hata verir. Bu kısıtlamalar bir nevi verilen Generic ifadenin ne tipte bir generic ifade olduğunu programa söyler, program da buna göre hareket eder. 
    public class EntityRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext db=new TContext())
            {
                var addEntity = db.Entry(entity);
                addEntity.State = EntityState.Added;
                DbSave(db);
            }
        }

        public void DeleteByEntity(TEntity entity)
        {
            using (TContext db=new TContext())
            {
                var deleteEntity = db.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                DbSave(db);
            }
        }

        public void DeleteByID(int id)
        {
            using (TContext db=new TContext())
            {
                var deleteEntity = db.Entry(GetByID(id));
                deleteEntity.State = EntityState.Deleted;
                DbSave(db);
            }
        }

        public List<TEntity> GetAll()
        {
            using (TContext db=new TContext())
            {
                return db.Set<TEntity>().ToList();
            }
        }

        public TEntity GetByEntity(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                return db.Set<TEntity>().Find(entity);
            }
        }

        public TEntity GetByID(int id)
        {
            using (TContext db = new TContext())
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public IQueryable<TEntity> GetEntitiesByFilter()
        {
            using (TContext db = new TContext())
            {
                return db.Set<TEntity>();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var updateDatabase = db.Entry(entity);
                updateDatabase.State = EntityState.Modified;
                DbSave(db);
            }
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
