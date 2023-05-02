using System.Security.Claims;

namespace API.Extensions
{
    /// <summary>
    /// Provides extension methods for working with ClaimsPrincipal objects.
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Retrieves the email address associated with the given ClaimsPrincipal, if one exists.
        /// </summary>
        /// <param name="user">The ClaimsPrincipal from which to retrieve the email address.</param>
        /// <returns>The email address associated with the ClaimsPrincipal, or null if none is found.</returns>
        public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }
    }

}
