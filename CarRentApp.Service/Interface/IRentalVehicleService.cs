using CarRentApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Service.Interface
{
    public interface IRentalVehicleService
    {
        public List<RentalVehicle> GetAllRentalVehicles();
        public RentalVehicle GetRentalVehicle(Guid Id);
        public RentalVehicle CreateRentalVehicle(RentalVehicle rentalVehicle);
        public RentalVehicle UpdateRentalVehicle(RentalVehicle vehicle);
        public void DeleteRentalVehicle(Guid Id);

    }
}
