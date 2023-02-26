using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prismatic.Core.Domain
{
    public interface IRepository<T>
    {
        public Task Add(T entity);

        public Task<T> Get(Guid id);

        public Task<List<T>> GetAll();
    }
}
