using CoreAppSkeleton.Data.Common.Models;
using CoreAppSkeleton.Data.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAppSkeleton.Data.Models;

namespace CoreAppSkeleton.DataConsole.UnitOfWork
{
    public class CoreAppSkeletonData : ICoreAppSkeletonData
    {
        private IDictionary<Type, object> repositories;

        public CoreAppSkeletonData(CoreAppSkeletonDbContext context)
        {
            this.Context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public CoreAppSkeletonDbContext Context { get; set; }

        public IRepository<CoreAppModel> CoreAppModels
        {
            get
            {
                return GetRepository<CoreAppModel>();
            }
        }

        public IDeletableEntityRepository<Blog> Blogs
        {
            get
            {
                return GetDeletableEntityRepository<Blog>();
            }
        }

        public IDeletableEntityRepository<Post> Posts
        {
            get
            {
                return GetDeletableEntityRepository<Post>();
            }
        }

        public async Task<int> SaveChanges()
        {
            return await this.Context.SaveChangesAsync();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.Context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(DeletableEntityRepository<T>), this.Context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeOfRepository];
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Context != null)
                {
                    this.Context.Dispose();
                }
            }
        }
    }
}
