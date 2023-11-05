using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Microservice.Core.Packages.Security.Encryption;

public class SecurityKeyHelper
{
    public static SecurityKey CreateSecurityKey(string securityKey)
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
