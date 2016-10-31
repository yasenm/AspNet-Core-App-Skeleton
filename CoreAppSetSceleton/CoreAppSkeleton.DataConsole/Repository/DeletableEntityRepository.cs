using CoreAppSkeleton.Data.Common.Models;
using CoreAppSkeleton.Data.Common.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppSkeleton.DataConsole
{
    public class DeletableEntityRepository<T> : GenericRepository<T>, IDeletableEntityRepository<T> where T : class, IDeletableEntity
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }

        public override void Delete(T entity)
        {
            entity.DeletedOn = DateTime.Now;
            entity.IsDeleted = true;

            var entry = this.DbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
