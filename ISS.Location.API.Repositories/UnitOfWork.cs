using System;
using ISS.Location.API.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace ISS.Location.API.Repositories
{
    public class UnitOfWork : IDisposable
    {
        #region Properties
        private readonly AppDbContext _dbContext;
        private readonly IDbContextTransaction _dbContextTransaction;
        #endregion

        #region Constructors
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContextTransaction = _dbContext.Database.BeginTransaction();
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (disposing)
                {
                    _dbContext.SaveChanges();
                    _dbContextTransaction.Commit();
                }
            }
            catch (Exception)
            {
                _dbContextTransaction.Rollback();

                throw;
            }
        }
    }
}
