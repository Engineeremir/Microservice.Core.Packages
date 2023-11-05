using Microservice.Core.Packages.Persistence.Repositories.EntityFramework;

namespace Microservice.Core.Packages.Security.Entities;

public class OperationClaim : Entity
{
    public string Name { get; set; }

    public OperationClaim()
    {
    }

    public OperationClaim(int id, string name) : base(id)
    {
        Name = name;
    }
}
