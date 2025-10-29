namespace Day_1.Repositry.Interface
{
    public interface IGenericRepositry <TEntity> where TEntity : class
    {
        public List<TEntity> GetAll();

        public TEntity GetById(int id);

        public TEntity GetByCondition(Expression<Func<TEntity, bool>> predicate);

        public void Add(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(int id);

    }
    
}
