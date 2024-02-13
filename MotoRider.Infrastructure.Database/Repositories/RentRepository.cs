using Microsoft.EntityFrameworkCore;
using MotoRider.Infrastructure.Database.Core;
using MotoRider.Infrastructure.Database.Repositories.Interfaces;
using MotoRider.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace MotoRider.Infrastructure.Database.Repositories
{
    public class RentRepository : Repository<Rent>, IRentRepository
    {
        public MotoRiderDbContext MotoRiderDbContext { get { return Context as MotoRiderDbContext; } }

        public RentRepository(MotoRiderDbContext context) : base(context)
        {
        }

        public IEnumerable<Rent> GetRents() => MotoRiderDbContext.Rents.Include("Motorcycle").Include("Customer");

        public Rent GetRent(int id) => GetRents().Single(rent => rent.Id == id);
    }
}
