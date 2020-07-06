using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotModelLayer
{
    public class VehicleType
    {
        [Required]
        public int VehicleId { get; set; }
        
        [Required]
        public string VehicleTypes { get; set; }
        
        [Required]
        public double Charges { get; set; }
    }
}
