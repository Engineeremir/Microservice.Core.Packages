namespace Microservice.Core.Packages.Persistence.Repositories.EntityFramework;

public class Entity
{
    public int Id { get; set; }
    public Entity()
    {
        
    }

    public Entity(int id):this()
    {
        Id = id;
    }
}
