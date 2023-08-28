using TechTask.DataBase;
using TechTask.Models.Entities;

namespace TechTask.Repositories;

public class ContactInfoRepository : Repository<ContactInfo>
{
    public ContactInfoRepository(ApplicationDbContext context) : base(context)
    {
    }
}