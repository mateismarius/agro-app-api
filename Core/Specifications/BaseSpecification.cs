using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    /// <summary>
    /// Represents a base specification for querying entities of type T from a database context.
    /// </summary>
    /// <typeparam name="T">The type of entity to query.</typeparam>
    public class BaseSpecification<T> : ISpecification<T>
    {
        /// <summary>
        /// Initializes a new instance of the BaseSpecification class.
        /// </summary>
        public BaseSpecification()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BaseSpecification class with the given criteria.
        /// </summary>
        /// <param name="criteria">The criteria to use for querying entities.</param>
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        /// <summary>
        /// Gets or sets the criteria to use for querying entities.
        /// </summary>
        public Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Gets the list of include expressions to use for including related entities in the query.
        /// </summary>
        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        /// <summary>
        /// Gets or sets the expression to use for ordering the query results in ascending order.
        /// </summary>
        public Expression<Func<T, object>> OrderBy { get; private set; }

        /// <summary>
        /// Gets or sets the expression to use for ordering the query results in descending order.
        /// </summary>
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        /// <summary>
        /// Gets or sets the number of entities to take in the query results.
        /// </summary>
        public int Take { get; private set; }

        /// <summary>
        /// Gets or sets the number of entities to skip in the query results.
        /// </summary>
        public int Skip { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether paging is enabled for the query.
        /// </summary>
        public bool IsPagingEnabled { get; private set; }

        /// <summary>
        /// Adds an include expression to use for including related entities in the query.
        /// </summary>
        /// <param name="includeExpression">The include expression to add.</param>
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        /// <summary>
        /// Adds an ordering expression to use for ordering the query results in ascending order.
        /// </summary>
        /// <param name="orderByExpression">The ordering expression to add.</param>
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        /// <summary>
        /// Adds an ordering expression to use for ordering the query results in descending order.
        /// </summary>
        /// <param name="orderByDescExpression">The ordering expression to add.</param>
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        /// <summary>
        /// Applies paging to the query results.
        /// </summary>
        /// <param name="skip">The number of entities to skip.</param>
        /// <param name="take">The number of entities to take.</param>
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
    
}
