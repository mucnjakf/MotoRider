using MotoRider.Infrastructure.Database.Core;
using MotoRider.Infrastructure.Database.Repositories.Interfaces;
using MotoRider.Shared.Models;

namespace MotoRider.Infrastructure.Database.Repositories
{
    public class MotorcycleRepository : Repository<Motorcycle>, IMotorcycleRepository
    {
        public MotoRiderDbContext MotoRiderDbContext { get { return Context as MotoRiderDbContext; } }

        public MotorcycleRepository(MotoRiderDbContext context) : base(context)
        {
        }
    }
}
