using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;
using Infrastructure.SpecEvaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntitiy
    {
        private readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves the count of entities of type T from the database that match the given specification asynchronously.
        /// </summary>
        /// <param name="spec">The specification to apply to the query.</param>
        /// <returns>An awaitable task that returns the count of entities of type T that match the given specification.</returns>
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            // Use the ApplySpecification method to apply the given specification to the database context and retrieve the query results.
            // Get the count of entities from the resulting IQueryable<T> object using the CountAsync method.
            // Return the resulting count of entities.
            return await ApplySpecification(spec).CountAsync();
        }

        /// <summary>
        /// Retrieves a single entity of type T from the database that matches the given ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>An awaitable task that returns the entity of type T that matches the given ID, or null if no matching entity is found.</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            // Retrieve a DbSet<T> object representing the entity collection from the database context.
            // Find the entity with the given ID using the FindAsync method.
            // Return the resulting entity, or null if no matching entity is found.
            return await _context.Set<T>().FindAsync(id);
        }


        /// <summary>
        /// Retrieves a single entity of type T from the database that matches the given specification asynchronously.
        /// </summary>
        /// <param name="spec">The specification to apply to the query.</param>
        /// <returns>An awaitable task that returns a single entity of type T that matches the given specification, or null if no matching entity is found.</returns>
        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            // Use the ApplySpecification method to apply the given specification to the database context and retrieve the query results.
            // Retrieve the first entity from the resulting IQueryable<T> object that matches the specification using the FirstOrDefaultAsync method.
            // Return the resulting entity, or null if no matching entity is found.
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }


        /// <summary>
        /// Retrieves a read-only list of all entities of type T from the database asynchronously.
        /// </summary>
        /// <returns>An awaitable task that returns a read-only list of all entities of type T in the database.</returns>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            // Retrieve a DbSet<T> object representing the entity collection from the database context.
            // Convert the DbSet<T> object to a list of entities asynchronously using the ToListAsync method.
            // Return the resulting read-only list of entities.
            return await _context.Set<T>().ToListAsync();
        }


        /// <summary>
        /// Retrieves a read-only list of entities that match the given specification from the database asynchronously.
        /// </summary>
        /// <param name="spec">The specification to apply to the query.</param>
        /// <returns>An awaitable task that returns a read-only list of entities that match the given specification.</returns>
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            // Use the ApplySpecification method to apply the given specification to the database context and retrieve the query results.
            // Convert the resulting IQueryable<T> object to a list of entities asynchronously using the ToListAsync method.
            // Return the resulting read-only list of entities.
            return await ApplySpecification(spec).ToListAsync();
        }


        /// <summary>
        /// Applies the given specification to the database context and returns an IQueryable<T> object that represents the query result.
        /// </summary>
        /// <param name="spec">The specification to apply to the query.</param>
        /// <returns>An IQueryable<T> object that represents the query result based on the given specification.</returns>
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            // Use the SpecificationEvaluator<T> class to evaluate the given specification against the database context.
            // Pass in the IQueryable<T> object representing the entity collection, and the specification to be applied.
            // Return the resulting IQueryable<T> object representing the query result.
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

    }
}
