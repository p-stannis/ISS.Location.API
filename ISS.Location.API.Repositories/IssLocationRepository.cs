using ISS.Location.API.Contracts;
using ISS.Location.API.Entities;

namespace ISS.Location.API.Repositories
{
    public class IssLocationRepository :  RepositoryBase<IssLocation>, IIssLocationRepository
    {
        public IssLocationRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
