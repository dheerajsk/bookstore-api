using EHealthcare.Entities;
using ProjectManagement.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ProjectManagementContext Context;

        public BaseRepository()
        {
            Context = DependencyResolver.Current.GetService<ProjectManagementContext>();
        }

        public async Task<T> Add(T entity)
        {
            Context.Add<T>(entity);
            await Context.SaveChangesAsync();
            return Get(entity.ID);
        }

        public async Task<int> Delete(long id)
        {
            Context.Remove<T>(Get(id));
            return await Context.SaveChangesAsync();
        }

        public IQueryable<T> Get()
        {
            return Context.Set<T>();
        }

        public T Get(long id)
        {
            return Context.Set<T>().Where(i => i.ID == id).FirstOrDefault();
        }

        public async Task<T> Update(T entity)
        {
            Context.Update<T>(entity);
            await Context.SaveChangesAsync();
            return Get(entity.ID);
        }
    }
}
