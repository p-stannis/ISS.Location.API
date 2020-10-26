using System;
using ISS.Location.API.Contracts;
using ISS.Location.API.Entities;

namespace ISS.Location.API.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _dbContext;

        private IIssLocationRepository _issLocation;

        public IIssLocationRepository IssLocation
        {
            get
            {
                if (_issLocation == null)
                {
                    _issLocation = new IssLocationRepository(_dbContext);
                }

                return _issLocation;
            }
        }

        public RepositoryWrapper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDisposable UseTransaction()
        {
            return new UnitOfWork(_dbContext);
        }
    }
}
