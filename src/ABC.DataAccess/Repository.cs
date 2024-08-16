
namespace ABC.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void DeleteBy(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public void DeleteBy(int id)
        {
            T entity = GetBy(id);
            context.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetBy(T entity)
        {
            return context.Set<T>().Find(entity);
        }

        public virtual T GetBy(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
