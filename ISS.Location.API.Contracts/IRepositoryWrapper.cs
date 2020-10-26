using System;
namespace ISS.Location.API.Contracts
{
    public interface IRepositoryWrapper
    {
        IIssLocationRepository IssLocation { get; }
        IDisposable UseTransaction();
    }
}
