using EHealthcare.Entities;
using ProjectManagement.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ProjectManagementContext Context;

        BaseRepository()
        {
            Context = DependencyResolver.Current.GetService<ProjectManagementContext>();
        }

        public IQueryable<T> Get()
        {
            return Context.Set<T>();
        }

        public T Get(long id)
        {
            return Context.Set<T>().Where(i => i.ID == id).FirstOrDefault();
        }

        public async Task<T> Add(T entity)
        {
            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(long id)
        {
            Context.Set<T>().Remove(Get(id));
            return await Context.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
    }
}
