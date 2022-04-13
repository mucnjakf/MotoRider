using MotoRider.Shared.Models;
using System.Collections.Generic;

namespace MotoRider.Core.Services.Interfaces
{
    public interface IRentService
    {
        IEnumerable<Rent> GetRents();

        Rent GetRent(int id);

        bool InsertRent(Rent rent);

        bool UpdateRent(int id, Rent rent);

        bool DeleteRent(int id);
    }
}
