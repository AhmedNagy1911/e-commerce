using Core.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;
using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static async Task<AppUser> GetUserByEmail(this UserManager<AppUser> userManager, ClaimsPrincipal user)
    {
        var usertoreturn = await userManager.Users.FirstOrDefaultAsync(x => x.Email == user.GetEmail());
        if (usertoreturn == null) throw new AuthenticationException("user not found");
        return usertoreturn;
    }
    public static async Task<AppUser> GetUserByEmailWithAddress(this UserManager<AppUser> userManager, ClaimsPrincipal user)
    {
        var usertoreturn = await userManager.Users
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Email == user.GetEmail());
        if (usertoreturn == null) throw new AuthenticationException("user not found");
        return usertoreturn;
    }
    public static string GetEmail(this ClaimsPrincipal user)
    {
        var email =user.FindFirstValue(ClaimTypes.Email) ?? throw new AuthenticationException("email claim not found");
        return email;
    }
}
