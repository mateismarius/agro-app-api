namespace API.Helpers
{
    /// <summary>
    /// Represents a paginated result set containing a subset of items from a larger collection, along with metadata about the pagination.
    /// </summary>
    /// <typeparam name="T">The type of items contained in the paginated result set.</typeparam>
    public class Pagination<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the Pagination class with the given pagination metadata and item data.
        /// </summary>
        /// <param name="pageIndex">The 0-based index of the current page within the larger result set.</param>
        /// <param name="pageSize">The maximum number of items to return per page.</param>
        /// <param name="count">The total number of items in the larger result set.</param>
        /// <param name="data">The subset of items to include in the current page of the paginated result set.</param>
        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
        }

        /// <summary>
        /// Gets or sets the 0-based index of the current page within the larger result set.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items to return per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total number of items in the larger result set.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the subset of items to include in the current page of the paginated result set.
        /// </summary>
        public IReadOnlyList<T> Data { get; set; }
    }

}
