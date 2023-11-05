using Microservice.Core.Packages.Security.Entities;

namespace Microservice.Core.Packages.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

    RefreshToken CreateRefreshToken(User user, string ipAddress);
}
