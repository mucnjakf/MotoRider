using MotoRider.Infrastructure.Database.Core;
using MotoRider.Infrastructure.Database.Repositories.Interfaces;
using MotoRider.Shared.Models;

namespace MotoRider.Infrastructure.Database.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public MotoRiderDbContext MotoRiderDbContext { get { return Context as MotoRiderDbContext; } }

        public CustomerRepository(MotoRiderDbContext context) : base(context)
        {
        }
    }
}
