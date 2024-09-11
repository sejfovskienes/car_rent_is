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
    public class RentedVehicleService : IRentedVehicleService
    {
        private readonly IRepository<RentedVehicle> _repository;
        public RentedVehicleService(IRepository<RentedVehicle> repository)
        {
            _repository = repository;
        }
        public RentedVehicle CreateRentedVehicle(RentedVehicle rentedVehicle)
        {
            return _repository.Insert(rentedVehicle);
        }

        public void DeleteRentalVehicle(Guid Id)
        {
            _repository.Delete(_repository.Get(Id));
        }

        public List<RentedVehicle> GetAllRentedVehicles()
        {
            return _repository.GetAll().ToList();
        }

        public RentedVehicle GetRentaedVehicle(Guid Id)
        {
            return _repository.Get(Id);
        }

        public RentedVehicle UpdateRentedVehicle(RentedVehicle rentedVehicle)
        {
            return _repository.Update(rentedVehicle);
        }
    }
}
