using Aurora.Services.UserManagement.Models;

namespace Aurora.Services.UserManagement.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
