using Data.Context;
using Domain.Entities;
using Domain.Interface.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqliteContext _sqLiteContext;

        public BaseRepository(SqliteContext mySqlContext)
            => _sqLiteContext = mySqlContext;

        public void Insert(TEntity obj)
        {
            _sqLiteContext.Set<TEntity>().Add(obj);
            _sqLiteContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _sqLiteContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqLiteContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _sqLiteContext.Set<TEntity>().Remove(Select(id));
            _sqLiteContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _sqLiteContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _sqLiteContext.Set<TEntity>().Find(id);

        public TEntity Select(string cep) =>
            _sqLiteContext.Set<TEntity>().Find(cep);
    }
}
