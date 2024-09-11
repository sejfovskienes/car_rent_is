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
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle> _repository;

        public VehicleService(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }
        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            return _repository.Insert(vehicle);
        }

        public void DeleteVehicle(Guid Id)
        {
            _repository.Delete(_repository.Get(Id));
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _repository.GetAll().ToList();
        }

        public Vehicle GetVehicle(Guid Id)
        {
            return _repository.Get(Id); 
        }

        public Vehicle UpdateVehicle(Vehicle vehicle)
        {
            return _repository.Update(vehicle);
        }
    }
}
