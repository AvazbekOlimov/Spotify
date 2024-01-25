using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class UnitOfWorkRepository(ApplicationDbContext dbContext, ICategory category,
    ISubCategory subCategory,
    IMusic music) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public ICategory Category { get; } = category;
    public ISubCategory SubCategory { get; } = subCategory;
    public IMusic Music { get; } = music;

    public void Dispose() => GC.SuppressFinalize(this);
    

    public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
}
