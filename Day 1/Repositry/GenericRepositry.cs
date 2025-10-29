using Day_1.Repositry.Interface;
using System.Linq;

namespace Day_1.Repositry
{
    public class GenericRepositry<TEntity> : IGenericRepositry<TEntity> where TEntity : class
    {
        readonly AppDbContext context;
        public GenericRepositry(AppDbContext context)
        {
            this.context = context;
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public void Delete(int id)
        {
            TEntity entity = GetById(id);
            context.Set<TEntity>().Remove(entity);
        }

        public TEntity GetByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().FirstOrDefault(predicate);
        }
    }

}
