using System.Security.Claims;

namespace PCBuilder.Services
{
    public class JwtService : IJwtService
    {
        public int GetUserId(ClaimsPrincipal user)
        {
            try
            {
                var id = int.Parse(user.Claims.First(x => x.Type == "id").Value);
                return id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public string GetUserRole(ClaimsPrincipal user)
        {
            var role = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            return role;
        }
    }
}
