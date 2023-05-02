using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    /// <summary>
    /// Represents a specification pattern for querying data of type T.
    /// </summary>
    /// <typeparam name="T">The type of data to query.</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets the filtering criteria for the query.
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Gets the related entities to include in the query.
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; }

        /// <summary>
        /// Gets the property to order the query results by in ascending order.
        /// </summary>
        Expression<Func<T, object>> OrderBy { get; }

        /// <summary>
        /// Gets the property to order the query results by in descending order.
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }

        /// <summary>
        /// Gets the number of entities to take in the query results.
        /// </summary>
        int Take { get; }

        /// <summary>
        /// Gets the number of entities to skip in the query results.
        /// </summary>
        int Skip { get; }

        /// <summary>
        /// Gets a value indicating whether paging is enabled for the query.
        /// </summary>
        bool IsPagingEnabled { get; }
    }

}
