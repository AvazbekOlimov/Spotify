using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class CategoryRepository : Repository<Category>, ICategory
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
