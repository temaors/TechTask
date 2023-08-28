using TechTask.DataBase;
using TechTask.Models.Entities;

namespace TechTask.Repositories;

public class BusinessAreaRepository : Repository<BusinessArea>
{
    public BusinessAreaRepository(ApplicationDbContext context) : base(context)
    {
    }
}