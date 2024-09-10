using CarRentApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentApp.Domain.Models
{
    public class RentedVehicle : BaseEntity
    {
        public Guid? RentalVehicleId { get; set; }
        public RentalVehicle? Vehicle { get; set; }
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? Charge { get; set; }
    }
}
