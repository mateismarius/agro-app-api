using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    /// <summary>
    /// Represents a specification for counting the number of product entities that match a set of filtering parameters.
    /// </summary>
    public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        /// <summary>
        /// Initializes a new instance of the ProductsWithFiltersForCountSpecification class with the given product parameters.
        /// </summary>
        /// <param name="productParams">The set of parameters to use for filtering the query.</param>
        public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams)
            : base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.CategoryId == productParams.BrandId) &&
                (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {

        }
    }

}
