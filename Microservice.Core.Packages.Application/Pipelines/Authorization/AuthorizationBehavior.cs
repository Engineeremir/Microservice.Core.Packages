using MediatR;
using Microservice.Core.Packages.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microservice.Core.Packages.Security.Extensions;
namespace Microservice.Core.Packages.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest,TResponse> :IPipelineBehavior<TRequest,TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest

{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

        if (roleClaims == null) throw new AuthorizationException("Claims not found.");

        bool isNotMatchedARoleClaimWithRequestRoles =
            roleClaims.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim)).IsNullOrEmpty();
        if (isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationException("You are not authorized.");

        TResponse response = await next();
        return response;
    }
}
