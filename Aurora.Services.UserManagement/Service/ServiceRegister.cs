using Aurora.Services.UserManagement.Service.IService;

namespace Aurora.Services.UserManagement.Service
{
    public static class ServiceRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var serviceDictonary = new Dictionary<Type, Type>
            {
                { typeof(IJwtTokenGenerator), typeof(JwtTokenGenerator) },
                { typeof(IAuthService), typeof(AuthService) }
               
            };
            return serviceDictonary;
        }
    }
}
