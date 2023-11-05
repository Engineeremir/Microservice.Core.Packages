using Microservice.Core.Packages.Security.EmailAuthenticator;
using Microservice.Core.Packages.Security.JWT;
using Microservice.Core.Packages.Security.OtpAuthenticator.OtpNet;
using Microservice.Core.Packages.Security.OtpAuthenticator;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Core.Packages.Security;

public static class SecurityServiceRegistration
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
        services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
        return services;
    }
}
