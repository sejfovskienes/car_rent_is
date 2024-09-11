using CarRentApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Service.Interface
{
    public interface IVehicleService
    {
        public List<Vehicle> GetAllVehicles();
        public Vehicle GetVehicle(Guid Id);
        public Vehicle CreateVehicle(Vehicle vehicle);
        public Vehicle UpdateVehicle(Vehicle vehicle);
        public void DeleteVehicle(Guid Id);
    }
}
