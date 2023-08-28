using TechTask.DataBase;
using TechTask.Models.Entities;

namespace TechTask.Repositories;

public class UserRepository : Repository<User>
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}