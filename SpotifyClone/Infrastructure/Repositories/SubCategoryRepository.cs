using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class SubCategoryRepository : Repository<SubCategory>, ISubCategory
{
    public SubCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
