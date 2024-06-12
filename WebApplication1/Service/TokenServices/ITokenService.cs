using Data;
using Microsoft.AspNetCore.Identity;
namespace WebApplication1.Service.TokenServices;

public interface ITokenService
{
    string CreateToken(User user, List<IdentityRole<long>> role);
}