using System.Security.Claims;

namespace PCBuilder.Services
{
    public interface IJwtService
    {
        public int GetUserId(ClaimsPrincipal user);
        public string GetUserRole(ClaimsPrincipal user);
    }
}
