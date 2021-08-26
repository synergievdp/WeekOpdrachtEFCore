using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core.Entities;
using WeekOpdrachtEFCore.Core.Interfaces.Repositories;

namespace WeekOpdrachtEFCore.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext context;
        private readonly DbSet<T> table;

        public Repository(DataContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public int Count(Expression<Func<T, bool>> filter = null)
        {
            return GetQuery(filter).Count();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return GetQuery(filter).FirstOrDefault();
        }

        public void Insert(T entity)
        {
            table.Add(entity);
            context.SaveChanges();
        }

        protected virtual IQueryable<T> GetQuery(Expression<Func<T, bool>> filter = null)
        {
            var query = table.AsQueryable();

            if (filter is not null)
                query = query.Where(filter);

            return query;
        }
    }
}
