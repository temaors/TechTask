using TechTask.DataBase;
using TechTask.Models.Entities;

namespace TechTask.Repositories;

public class LocationRepository : Repository<Location>
{
    public LocationRepository(ApplicationDbContext context) : base(context)
    {
    }
}