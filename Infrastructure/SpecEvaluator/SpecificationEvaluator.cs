using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SpecEvaluator
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntitiy
    {
        /// <summary>
        /// The method starts by creating a copy of the input query and applies the filters defined in the specification 
        /// by calling the Where method on the query. Then, if the specification specifies ordering, 
        /// the method applies the ordering using the OrderBy or OrderByDescending method. If paging is enabled, 
        /// the method applies the paging by calling Skip and Take on the query.
        /// </summary>
        /// <param name="inputQuery"></param>
        /// <param name="spec"></param>
        /// <returns>The method returns the resulting query as an IQueryable<TEntity> 
        /// which can be further processed or executed to retrieve the desired entities.
        /// </returns>
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);
            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);
            if (spec.OrderByDescending != null)
                query = query.OrderByDescending(spec.OrderByDescending);
            if (spec.IsPagingEnabled)
                query = query.Skip(spec.Skip).Take(spec.Take);

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
