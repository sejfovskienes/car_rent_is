using CarRentApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Service.Interface
{
    public interface IRentedVehicleService
    {
        public List<RentedVehicle> GetAllRentedVehicles();
        public RentedVehicle GetRentaedVehicle(Guid Id);
        public RentedVehicle CreateRentedVehicle(RentedVehicle rentedVehicle);
        public RentedVehicle UpdateRentedVehicle(RentedVehicle rentedVehicle);
        public void DeleteRentalVehicle(Guid Id);
    }
}
