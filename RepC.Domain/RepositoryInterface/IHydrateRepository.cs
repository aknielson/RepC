using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepC.Domain.RepositoryInterface
{
    public interface IHydrateRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        TEntity GetHydrated(int id);
        
        TEntity Hydrate(TEntity entity);

        TEntity SingleHydrated(Expression<Func<TEntity, bool>> predicate);

        void AddHydrated(TEntity entity);

       


    }
}
