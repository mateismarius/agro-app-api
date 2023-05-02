namespace API.Errors
{
    /// <summary>
    /// Represents an API exception that can be returned to clients as a JSON response.
    /// </summary>
    public class ApiException : ApiResponse
    {
        /// <summary>
        /// Initializes a new instance of the ApiException class with the specified status code, message, and details.
        /// </summary>
        /// <param name="statusCode">The HTTP status code of the exception.</param>
        /// <param name="message">The message of the exception.</param>
        /// <param name="details">The details of the exception.</param>
        public ApiException(int statusCode, string message = null, string details = null) :
            base(statusCode, message)
        {
            Details = details;
        }

        /// <summary>
        /// Gets or sets the details of the exception.
        /// </summary>
        public string Details { get; set; }
    }

}
