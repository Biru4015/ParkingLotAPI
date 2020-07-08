using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingLotModelLayer
{
    /// <summary>
    /// This class contains the details of parking type.
    /// </summary>
    public class ParkingType
    {
        /// <summary>
        /// This  is parking id
        /// </summary>
        [Key]
        public int ParkingId { get; set; }

        /// <summary>
        /// This is parking type.
        /// </summary>
        [Required]
        public string ParkingTypes { get; set; }
        
        /// <summary>
        /// This is charges for vehicle
        /// </summary>
        [Required]
        public double Charges { get; set; }
    }
}
