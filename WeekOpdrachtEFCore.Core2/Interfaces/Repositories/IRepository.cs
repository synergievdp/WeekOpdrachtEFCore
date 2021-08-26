using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeekOpdrachtEFCore.Core2.Entities;

namespace WeekOpdrachtEFCore.Core2.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        public int Count(Expression<Func<T, bool>> filter = null);
        public T Get(Expression<Func<T, bool>> filter);
        public void Insert(T entity);
    }
}
