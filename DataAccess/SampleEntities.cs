namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public partial class SampleEntities : IRepository
    {
        public T Add<T>(T entity) where T : class
        {
            var set = this.Set<T>();
            set.Add(entity);
            SaveChanges();
            return entity;
        }

        public void Delete<T>(T entity) where T : class
        {
            var set = this.Set<T>();
            set.Remove(entity);
            SaveChanges();
        }

        public T Edit<T>(T entity) where T : class
        {
            var set = this.Set<T>();
            set.Attach(entity);
            this.Entry(entity).State = EntityState.Modified;
            SaveChanges();
            return entity;
        }

        public IQueryable<T> Get<T>() where T : class
        {
            return this.Set<T>().AsQueryable<T>();
        }

        public T Get<T>(int id) where T : class
        {
            return this.Set<T>().Find(id);
        }
    }
}
