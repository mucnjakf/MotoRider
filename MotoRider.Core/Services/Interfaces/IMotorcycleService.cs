using MotoRider.Shared.Models;
using System.Collections.Generic;

namespace MotoRider.Core.Services.Interfaces
{
    public interface IMotorcycleService
    {
        IEnumerable<Motorcycle> GetMotorcycles();

        Motorcycle GetMotorcycle(int id);

        bool InsertMotorcycle(Motorcycle motorcycle);

        bool UpdateMotorcycle(int id, Motorcycle motorcycle);

        bool DeleteMotorcycle(int id);
    }
}
