using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Extensions
{
    /// <summary>
    /// Provides extension methods for working with the UserManager class.
    /// </summary>
    public static class UserManagerExtensions
    {
        /// <summary>
        /// Finds and returns the AppUser associated with the given ClaimsPrincipal, including the user's associated Address entity.
        /// </summary>
        /// <param name="userManager">The UserManager instance to use for querying the user store.</param>
        /// <param name="user">The ClaimsPrincipal for which to find the associated AppUser.</param>
        /// <returns>The AppUser associated with the ClaimsPrincipal, including the user's associated Address entity.</returns>
        public static async Task<AppUser> FindUserByClaimsPrincipleWithAddress(this UserManager<AppUser> userManager,
            ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email);

#pragma warning disable CS8603 // Possible null reference return.
            return await userManager.Users.Include(x => x.Address)
                .SingleOrDefaultAsync(x => x.Email == email);
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Finds and returns the AppUser associated with the given ClaimsPrincipal, based on the user's email address.
        /// </summary>
        /// <param name="userManager">The UserManager instance to use for querying the user store.</param>
        /// <param name="user">The ClaimsPrincipal for which to find the associated AppUser.</param>
        /// <returns>The AppUser associated with the ClaimsPrincipal, based on the user's email address.</returns>
        public static async Task<AppUser> FindByEmailFromClaimsPrincipal(this UserManager<AppUser> userManager,
            ClaimsPrincipal user)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await userManager.Users
                .SingleOrDefaultAsync(x => x.Email == user.FindFirstValue(ClaimTypes.Email));
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

}
