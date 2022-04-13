using MotoRider.Core.Services.Interfaces;
using MotoRider.Infrastructure.Database.Core;
using MotoRider.Infrastructure.Database.Core.Interfaces;
using MotoRider.Shared.Models;
using System;
using System.Collections.Generic;

namespace MotoRider.Core.Services
{
    public class RentService : IRentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentService()
        {
            _unitOfWork = new UnitOfWork(new MotoRiderDbContext());
        }

        public IEnumerable<Rent> GetRents()
        {
            try
            {
                return _unitOfWork.Rents.GetRents();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Rent GetRent(int id)
        {
            try
            {
                return _unitOfWork.Rents.GetRent(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool InsertRent(Rent rent)
        {
            try
            {
                Motorcycle motorcycle = _unitOfWork.Motorcycles.Get(rent.MotorcycleId);
                motorcycle.AvailableForRent = false;

                _unitOfWork.Rents.Add(rent);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateRent(int id, Rent rent)
        {
            try
            {
                Rent rentToUpdate = _unitOfWork.Rents.Get(id);

                if (rentToUpdate == null) return false;

                rentToUpdate.DateRented = rent.DateRented;
                rentToUpdate.RentedUntil = rent.RentedUntil;
                rentToUpdate.Price = rent.Price;
                rentToUpdate.Completed = rent.Completed;

                Motorcycle oldMotorcycle = _unitOfWork.Motorcycles.Get(rentToUpdate.MotorcycleId);
                Motorcycle newMotorcycle = _unitOfWork.Motorcycles.Get(rent.MotorcycleId);

                if (oldMotorcycle != newMotorcycle)
                {
                    oldMotorcycle.AvailableForRent = true;
                    newMotorcycle.AvailableForRent = false;
                }
                else
                {
                    oldMotorcycle.AvailableForRent = false;
                }
                
                rentToUpdate.MotorcycleId = rent.MotorcycleId;
                rentToUpdate.CustomerId = rent.CustomerId;

                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRent(int id)
        {
            try
            {
                Rent rent = _unitOfWork.Rents.Get(id);

                if (rent == null) return false;

                Motorcycle motorcycle = _unitOfWork.Motorcycles.Get(rent.MotorcycleId);
                motorcycle.AvailableForRent = true;

                _unitOfWork.Rents.Remove(rent);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
