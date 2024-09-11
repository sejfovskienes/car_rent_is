using CarRentApp.Domain.Models;
using CarRentApp.Repository.Interface;
using CarRentApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Service.Implementation
{
    public class RentalVehicleService : IRentalVehicleService
    {
        private readonly IRepository<RentalVehicle> _repository;
        public RentalVehicleService(IRepository<RentalVehicle> repository)
        {
            _repository = repository;
        }
        public RentalVehicle CreateRentalVehicle(RentalVehicle rentalVehicle)
        {
            return _repository.Insert(rentalVehicle);
        }

        public void DeleteRentalVehicle(Guid Id)
        {
            _repository.Delete(_repository.Get(Id));
        }

        public List<RentalVehicle> GetAllRentalVehicles()
        {
            return _repository.GetAll().ToList();
        }

        public RentalVehicle GetRentalVehicle(Guid Id)
        {
            return _repository.Get(Id);
        }

        public RentalVehicle UpdateRentalVehicle(RentalVehicle vehicle)
        {
            return _repository.Update(vehicle);
        }
    }
}
