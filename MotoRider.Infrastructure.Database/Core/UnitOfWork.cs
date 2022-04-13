using MotoRider.Infrastructure.Database.Core.Interfaces;
using MotoRider.Infrastructure.Database.Repositories;
using MotoRider.Infrastructure.Database.Repositories.Interfaces;

namespace MotoRider.Infrastructure.Database.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MotoRiderDbContext _context;

        public IMotorcycleRepository Motorcycles { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public IRentRepository Rents { get; private set; }

        public IUserRepository Users{ get; private set; }

        public UnitOfWork(MotoRiderDbContext context)
        {
            _context = context;

            Motorcycles = new MotorcycleRepository(_context);

            Customers = new CustomerRepository(_context);

            Rents = new RentRepository(_context);

            Users = new UserRepository(_context);
        }

        public int Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
