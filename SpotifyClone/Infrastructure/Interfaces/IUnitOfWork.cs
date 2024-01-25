namespace Infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{ 
    public ICategory Category { get; }
    public ISubCategory SubCategory { get; }
    public IMusic Music { get; }
    Task SaveAsync();
}
