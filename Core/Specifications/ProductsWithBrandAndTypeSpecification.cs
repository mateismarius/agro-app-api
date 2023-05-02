using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    /// <summary>
    /// Represents a specification for retrieving product entities with their associated product types and brands from a database context.
    /// </summary>
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        /// <summary>
        /// Initializes a new instance of the ProductsWithTypesAndBrandsSpecification class with the given product parameters.
        /// </summary>
        /// <param name="productParams">The set of parameters to use for filtering and sorting the query.</param>
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {
            // Include the associated product type and brand entities in the query results.
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

            // Order the query results by name by default.
            AddOrderBy(x => x.Name);

            // Apply paging to the query results based on the given parameters.
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),
                productParams.PageSize);

            // Apply any additional sorting based on the given parameters.
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the ProductsWithTypesAndBrandsSpecification class with the given product ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        public ProductsWithTypesAndBrandsSpecification(int id)
            : base(x => x.Id == id)
        {
            // Include the associated product type and brand entities in the query results.
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }


}
