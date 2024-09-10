using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Domain.Models
{
    public class RentalVehicle : BaseEntity
    {
        public Guid? VehicleId { get; set; } 
        public Vehicle? Vehicle { get; set; }
        public string? MinimumRentalTime { get; set; }
        public string? MaximumRentalTime { get; set; }
        public int? DailyRentalRate { get; set; }
        public bool? isAvailable { get; set; }
    }
}
