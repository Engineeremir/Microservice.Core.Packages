namespace Microservice.Core.Packages.Persistence.Repositories.EntityFramework;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
