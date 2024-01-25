using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class MusicRepository : Repository<Music>, IMusic
{
    public MusicRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
