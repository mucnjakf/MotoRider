using MotoRider.Shared.Models;
using System.Collections.Generic;

namespace MotoRider.Infrastructure.Database.Repositories.Interfaces
{
    public interface IRentRepository : IRepository<Rent>
    {
        public IEnumerable<Rent> GetRents();
        public Rent GetRent(int id);
    }
}
