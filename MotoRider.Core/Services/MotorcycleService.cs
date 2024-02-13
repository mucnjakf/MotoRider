using MotoRider.Core.Services.Interfaces;
using MotoRider.Infrastructure.Database.Core;
using MotoRider.Infrastructure.Database.Core.Interfaces;
using MotoRider.Shared.Models;
using System;
using System.Collections.Generic;

namespace MotoRider.Core.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MotorcycleService()
        {
            _unitOfWork = new UnitOfWork(new MotoRiderDbContext());
        }

        public IEnumerable<Motorcycle> GetMotorcycles()
        {
            try
            {
                return _unitOfWork.Motorcycles.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Motorcycle GetMotorcycle(int id)
        {
            try
            {
                return _unitOfWork.Motorcycles.Get(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool InsertMotorcycle(Motorcycle motorcycle)
        {
            try
            {
                _unitOfWork.Motorcycles.Add(motorcycle);
                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateMotorcycle(int id, Motorcycle motorcycle)
        {
            try
            {
                Motorcycle motorcycleToUpdate = _unitOfWork.Motorcycles.Get(id);

                if (motorcycleToUpdate == null) return false;

                motorcycleToUpdate.Make = motorcycle.Make;
                motorcycleToUpdate.Model = motorcycle.Model;
                motorcycleToUpdate.YearOfManufacture = motorcycle.YearOfManufacture;
                motorcycleToUpdate.Mileage = motorcycle.Mileage;
                motorcycleToUpdate.Price = motorcycle.Price;
                motorcycleToUpdate.AvailableForRent = motorcycle.AvailableForRent;

                _unitOfWork.Complete();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteMotorcycle(int id)
        {
            try
            {
                Motorcycle motorcycle = _unitOfWork.Motorcycles.Get(id);

                if (motorcycle == null) return false;

                _unitOfWork.Motorcycles.Remove(motorcycle);
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
