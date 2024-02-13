using MotoRider.Infrastructure.Database.Repositories.Interfaces;
using System;

namespace MotoRider.Infrastructure.Database.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMotorcycleRepository Motorcycles { get; }

        ICustomerRepository Customers { get; }

        IRentRepository Rents { get; }

        IUserRepository Users { get; }

        int Complete();
    }
}
