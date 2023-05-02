using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    /// <summary>
    /// Represents a set of parameters for filtering and sorting product entities.
    /// </summary>
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;

        /// <summary>
        /// Gets or sets the index of the page to retrieve.
        /// </summary>
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        /// <summary>
        /// Gets or sets the maximum number of entities to retrieve per page.
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        /// <summary>
        /// Gets or sets the ID of the brand to filter by.
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product type to filter by.
        /// </summary>
        public int? TypeId { get; set; }

        /// <summary>
        /// Gets or sets the property to sort the results by.
        /// </summary>
        public string Sort { get; set; }

        private string _search = "";

        /// <summary>
        /// Gets or sets the search term to use for filtering the results.
        /// </summary>
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }

}
