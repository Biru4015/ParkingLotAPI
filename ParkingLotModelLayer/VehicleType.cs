using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotModelLayer
{
    /// <summary>
    /// This code contains the code of vehicleType details
    /// </summary>
    public class VehicleType
    {
        /// <summary>
        /// This is vehicle id
        /// </summary>
        [Required]
        public int VehicleId { get; set; }
        
        /// <summary>
        /// This  is vehicle types
        /// </summary>
        [Required]
        public string VehicleTypes { get; set; }
        
        /// <summary>
        /// This is charges of vehicles
        /// </summary>
        [Required]
        public double Charges { get; set; }
    }
}
